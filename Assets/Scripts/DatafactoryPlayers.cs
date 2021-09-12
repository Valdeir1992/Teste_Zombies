using UnityEngine;

/// <summary>
/// Script responsável por injetar dependencias relacionadas ao personagem
/// </summary>
public class DatafactoryPlayers:MonoBehaviour
{
    #region PRIVATE VARIABLES

    private IInput _inputs; 

    private static DatafactoryPlayers _instance;

    [SerializeField] private GameObject[] _prefabsCharacter;
    #endregion

    #region PUBLIC VARIABLES
    public static DatafactoryPlayers Instance { get => _instance; }
    #endregion
    #region UNITY METHODS
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(gameObject);

        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region OWN METHODS
    public IInput GetInputs()
    {
        if(_inputs == null)
        {
            _inputs = new InputPlayer();
        }
        return _inputs;
    }

    public GameObject GetPlayer(int selectedCharacter)
    {
        return _prefabsCharacter[selectedCharacter];
    }
    #endregion
}