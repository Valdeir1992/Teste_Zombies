using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script responsável por injetar dependencias.
/// </summary>
public class Datafactory:MonoBehaviour
{
    #region PRIVATE VARIABLES
    private GameplayerController _gameplayer; 

    private static Datafactory _instance; 

    [SerializeField] private GameObject _prefabFadeController;
    #endregion

    #region PUBLIC VARIABLES
    public static Datafactory Instance
    {
        get => _instance;
    }
    #endregion

    #region UNITY METHODS 
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(gameObject);

        }else if(_instance != this)
        {
            Destroy(gameObject);
        }
        SceneManager.sceneUnloaded += (scene) => _gameplayer = null;
    }
    #endregion

    #region OWN METHODS

    /// <summary>
    /// Método que retornar o sistema de fade ou instancia um caso nao haja na cena.
    /// </summary>
    /// <returns></returns>
    public IFadeController GetFadeController()
    {  
        var fade = FindObjectsOfType<MonoBehaviour>().OfType<IFadeController>().ToArray(); 

        if(fade.Length == 0)
        { 
            return Instantiate(_prefabFadeController).GetComponent<IFadeController>();
        }
        else
        {
            return fade[0];
        }
    }

    /// <summary>
    /// Método que retonar o componente GameplayerController.
    /// </summary>
    /// <returns></returns>
    public GameplayerController GetGameplayerComponent()
    {
        if(UnityEngine.Object.ReferenceEquals(_gameplayer,null))
        {
            _gameplayer = FindObjectOfType<GameplayerController>();
        }
        return _gameplayer;
    }

    /// <summary>
    /// Método que retorna o compornent LoadController ou instancia um caso nao haja um na cena.
    /// </summary>
    /// <returns></returns>
    public ILoadController GetLoadController()
    {
        var fade = FindObjectsOfType<MonoBehaviour>().OfType<ILoadController>().ToArray();

        if (fade.Length == 0)
        {
            return new GameObject("LoadController").AddComponent<LoadController>();
        }
        else
        {
            return fade[0];
        }
    }

    /// <summary>
    /// Método que returnar o input do jogador.
    /// </summary>
    /// <returns></returns>
    public IInput GetInputs()
    {
        return new InputPlayer();
    }
    #endregion
}