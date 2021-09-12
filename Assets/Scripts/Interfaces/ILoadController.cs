using System;
/// <summary>
/// Interface para o gerenciamento do load do game.
/// </summary>
public interface ILoadController
{
    /// <summary>
    /// Método responsavel por carregar novos cenarios de forma assincrona.
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    bool Load(int v);
}