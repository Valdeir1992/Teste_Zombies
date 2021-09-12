using System;
using System.Collections;

/// <summary>
/// Interface que define o sistema de fade
/// </summary>
public interface IFadeController
{
    /// <summary>
    /// Coroutina responsável por executar o fadeIn.
    /// </summary>
    /// <param name="time">variável que define o tempo de execucao do fadeIn</param>
    /// <param name="callBack">Método que pode ser executado 0.5 secundos após a finalizacao do fade</param>
    /// <returns></returns>
    IEnumerator Coroutine_FadeIn(float time, Func<bool> callBack = null);
    /// <summary>
    /// Coroutina responsável por executar o fadeOut.
    /// </summary>
    /// <param name="time">variável que define o tempo de execucao do fadeIn</param>
    /// <param name="callBack">Método que pode ser executado 0.5 secundos após a finalizacao do fade</param>
    /// <returns></returns>
    IEnumerator Coroutine_FadeOut(float time, Func<bool> callBack = null);
}