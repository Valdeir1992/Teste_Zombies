using System.Collections; 
using UnityEngine;
using System.Linq;

/// <summary>
/// Script responsável por gerenciar a splashScreen. 
/// </summary>
public class SplashScreen : MonoBehaviour
{
    #region PRIVATE VARIABLES

    private IFadeController _fadeController;

    private ILoadController _loadController;

    private AsyncOperation _asyncAction;
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _fadeController = FindObjectsOfType<MonoBehaviour>().OfType<IFadeController>().FirstOrDefault();

        _loadController = FindObjectsOfType<MonoBehaviour>().OfType<ILoadController>().FirstOrDefault();
    }

    private void Start()
    {
        StartCoroutine(Coroutine_SplashScreen());
    }
    #endregion 
     
    #region COROUTINES

    /// <summary>
    /// Coroutine responsável por executar a splashScreen.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Coroutine_SplashScreen()
    {
        yield return _fadeController.Coroutine_FadeIn(2);

        yield return _fadeController.Coroutine_FadeOut(2,()=>_loadController.Load(1));
    }
    #endregion
}
