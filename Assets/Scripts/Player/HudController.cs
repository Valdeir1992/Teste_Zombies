using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script responsável por gerenciar hub de vida do jogador.
/// </summary>
public class HudController : MonoBehaviour, IHudController
{
    #region PRIVATE VARIABLES
    private ICharacterMediator _player;

    private Transform _playerPosition;

    private RectTransform _image; 

    private Canvas _canvasLife;

    private Image _spriteImage;

    [SerializeField] private GameObject _prefabLife;
    #endregion

    #region UNITY METHODS
    private void Awake()
    { 
        _canvasLife = GameObject.Find("CanvasLife").GetComponent<Canvas>();
    }

    private void Start()
    {
        _image = Instantiate(_prefabLife, _canvasLife.transform).GetComponent<RectTransform>();

        _spriteImage = _image.GetChild(0).GetComponent<Image>();

        _spriteImage.color = Color.green;

        InvokeRepeating("MoveHudLife", 0, 0.01f); 
    }
    #endregion

    #region OWN METHODS
    public void Configure(ICharacterMediator character)
    {
        _player = character;
        _playerPosition = ((MonoBehaviour)_player).transform;
    }

    public void TakeDamage(float amount)
    {
        _spriteImage.fillAmount = amount / _player.Data.LifeMax;

        if(_spriteImage.fillAmount >= 0.5f)
        {
            _spriteImage.color = Color.green;
        }else if(_spriteImage.fillAmount < 0.5f && _spriteImage.fillAmount >= 0.25f)
        {
            _spriteImage.color = Color.yellow;
        }
        else if(_spriteImage.fillAmount < 0.25f)
        {
            _spriteImage.color = Color.red;
        }
    }

    private void MoveHudLife()
    {
        Vector2 pos = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasLife.transform as RectTransform,
            Camera.main.WorldToScreenPoint(_playerPosition.position + Vector3.up * 4), null, out pos);

        _image.anchoredPosition = pos;
    }

    #endregion
}
