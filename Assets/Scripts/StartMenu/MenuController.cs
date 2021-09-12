using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script responsavel por gerenciar o menu inicial
/// </summary>
public class MenuController : MonoBehaviour
{
    #region PRIVATE VARIABLES

    private IFadeController _fadeController;

    private ILoadController _loadController;

    private IInput _input;

    private AudioSource _emissior;

    private int _playerSelected;

    private Dictionary<int, ICharacterMenu> _characterDict = new Dictionary<int, ICharacterMenu>();

    [SerializeField] private Image _selector;

    [SerializeField] private Button _btnPlay;

    [SerializeField] private GameplayerData _data;
    #endregion 

    #region UNITY METHODS
    private void Awake()
    {
        _fadeController = Datafactory.Instance.GetFadeController();

        _loadController = Datafactory.Instance.GetLoadController();

        var characters = FindObjectsOfType<MonoBehaviour>().OfType<ICharacterMenu>().ToArray();

        foreach (var item in characters)
        {
            if (!_characterDict.ContainsKey(item.Id))
            { 
                _characterDict.Add(item.Id, item);
            } 
        }

        _input = Datafactory.Instance.GetInputs();

        _emissior = GetComponent<AudioSource>();

        _btnPlay.onClick.AddListener(StartGameplayer);

        Cursor.SetCursor(null, new Vector2(64, 64), cursorMode: CursorMode.ForceSoftware);
    }
    private void Start()
    {  
        StartCoroutine(_fadeController.Coroutine_FadeIn(2));
    }

    private void Update()
    {
        SelectCharacter();
    }
    #endregion

    #region OWN METHODS
    /// <summary>
    /// Método que iniciar o gameplayer.
    /// </summary>
    private void StartGameplayer()
    {
        _btnPlay.interactable = false;
        StartCoroutine(Coroutine_StartGameplayer());
    }

    private void SelectCharacter()
    {
        int currentValue = _playerSelected;

        _playerSelected += _input.SelectedCharacter();

        if (currentValue != _playerSelected)
        { 
            if (_playerSelected < 0)
            {
                _playerSelected = 2;
            }
            else if (_playerSelected > 2)
            {
                _playerSelected = 0;
            }

            ChangePositionSelector();

            _characterDict[_playerSelected].Execute();
        } 
    }

    private void ChangePositionSelector()
    {
        switch (_playerSelected)
        {
            case 0:
                _selector.rectTransform.anchoredPosition = new Vector2(-300, 90); 
                break;
            case 1:
                _selector.rectTransform.anchoredPosition = new Vector2(40, 90);
                break;
            case 2:
                _selector.rectTransform.anchoredPosition = new Vector2(360, 90);
                break;
        }  
    }
    #endregion

    #region COROUTINES
    /// <summary>
    /// Coroutine que iniciar o gameplayer.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Coroutine_StartGameplayer()
    {
        _emissior.Stop();

        _data.SetCharacter(_playerSelected);

        yield return _fadeController.Coroutine_FadeOut(2, () => _loadController.Load(2));
    }
    #endregion 
}
