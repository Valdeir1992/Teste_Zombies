using System;
using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script responsável por executar fade.
/// </summary>
public class FadeController : MonoBehaviour,IFadeController
{
    #region PRIVATE VARIABLES

    private CanvasGroup _canvasFade;  
    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        _canvasFade = GetComponent<CanvasGroup>(); 

        DontDestroyOnLoad(gameObject);
    } 
    #endregion 

    #region COROUTINES 

    public IEnumerator Coroutine_FadeIn(float time, Func<bool> callBack)
    {
        float timeElapsed = 0; 

        while (timeElapsed/time <= 1)
        {
            timeElapsed += Time.deltaTime;

            _canvasFade.alpha = Mathf.Lerp(1,0,timeElapsed/time);

            yield return null;
        } 
        _canvasFade.alpha = 0;

        _canvasFade.blocksRaycasts = false; 

        yield return new WaitForSeconds(0.5f);

        if(callBack != null)
        {
            yield return new WaitUntil(() => callBack());
        }

        yield break;
    } 
     
    public IEnumerator Coroutine_FadeOut(float time, Func<bool> callBack)
    {
        float timeElapsed = 0; 

        _canvasFade.blocksRaycasts = true; 

        while (timeElapsed / time <= 1)
        {
            timeElapsed += Time.deltaTime;

            _canvasFade.alpha = Mathf.Lerp(0, 1, timeElapsed / time);

            yield return null;
        }
        _canvasFade.alpha = 1; 

        yield return new WaitForSeconds(0.5f);

        if (callBack != null)
        {
            yield return new WaitUntil(() => callBack());
        }

        yield break;
    }
    #endregion
}
