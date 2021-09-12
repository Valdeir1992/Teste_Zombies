using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    private ILoadController _loadController;
    private IFadeController _fadeControllar;
    [SerializeField] private Button _btnRetry;
    [SerializeField] private Button _btnMenu;

    private void Awake()
    {
        _loadController = Datafactory.Instance.GetLoadController();

        _fadeControllar = Datafactory.Instance.GetFadeController();

        _btnRetry.onClick.AddListener(Retry);

        _btnMenu.onClick.AddListener(Menu);
    }

    private void Menu()
    {
        StartCoroutine(Coroutine_Menu());
    }

    private void Retry()
    {
        StartCoroutine(Coroutine_Retry());
    }

    private IEnumerator Coroutine_Menu()
    {
        _btnMenu.interactable = false;

        _btnRetry.interactable = false;

        yield return _fadeControllar.Coroutine_FadeOut(2, () => _loadController.Load(1)); 
    }

    private IEnumerator Coroutine_Retry()
    { 
        _btnMenu.interactable = false;

        _btnRetry.interactable = false;

        yield return _fadeControllar.Coroutine_FadeOut(2, () => _loadController.Load(2));
    }
}
