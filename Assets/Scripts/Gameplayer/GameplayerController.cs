using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayerController : MonoBehaviour,IGameplayer
{ 
    private IFadeController _fadeController;

    private ILoadController _loadController;

    private ISaveController _saveController;

    private int _currentScore;

    [SerializeField] private Texture2D _cursor;

    [SerializeField] private TextMeshProUGUI _currentScoreHud;

    [SerializeField] private TextMeshProUGUI _theBestScore;

    [SerializeField] private TextMeshProUGUI _theCurrentScore;

    [SerializeField] private CanvasGroup _gameOver;

    [SerializeField] private Transform _startPosition;

    [SerializeField] private GameplayerData _data;

    private void Awake()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        _saveController = new SaveControllerAdapterWindowns();
#endif
        _fadeController = Datafactory.Instance.GetFadeController();

        _loadController = Datafactory.Instance.GetLoadController();
    }

    private void Start()
    {
        StartCoroutine(_fadeController.Coroutine_FadeIn(2));

        SpawnCharacter();

        Cursor.SetCursor(_cursor, new Vector2(64,64), cursorMode: CursorMode.ForceSoftware);
    }


    private void SpawnCharacter()
    {
        GameObject character = Instantiate(DatafactoryPlayers.Instance.GetPlayer(_data.SelectedCharacter), _startPosition.position, Quaternion.identity);

        ICharacterMediator player = character.GetComponent<ICharacterMediator>();

        IMotionController motion = character.gameObject.AddComponent<MotionController>();

        ILifeController life = character.gameObject.AddComponent<LifeController>();

        player.Install(motion,life);
    }

    public void GameOver()
    {
        _saveController.Save(_currentScore);

        _theBestScore.text = _saveController.CurrentSave.TheBestScore.ToString();

        _theCurrentScore.text = _saveController.CurrentSave.TheLastScore.ToString();

        _gameOver.alpha = 1;

        _gameOver.blocksRaycasts = true;
    }

    public void AddPoints(int score)
    { 
        _currentScore += score;

        _currentScoreHud.text = $"Pontuação:{_currentScore}";
    }
}
