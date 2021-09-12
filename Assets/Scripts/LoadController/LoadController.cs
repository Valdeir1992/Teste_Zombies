using System;
using UnityEngine;

/// <summary>
/// Script que gerencia o load do game.
/// </summary>
public class LoadController : MonoBehaviour, ILoadController
{
    #region PRIVATE VARIABLES

    private AsyncOperation _asyncAction;
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region OWN METHODS
    public bool Load(int v)
    {
        if (_asyncAction == null)
        {
            _asyncAction = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(v);

            _asyncAction.allowSceneActivation = false;

            return false;
        }
        else
        {
            if (_asyncAction.progress <= 0.80f)
            {
                return false;
            }
            else
            {
                _asyncAction.allowSceneActivation = true;
                _asyncAction = null;
                return true;
            }
        }
    }
    #endregion
}
