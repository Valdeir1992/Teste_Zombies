using UnityEngine;

/// <summary>
/// Interface responsavel por definir inputs do jogador.
/// </summary>
public interface IInput
{
    /// <summary>
    /// Método responsavel por selecionar personagem no menu inicial
    /// </summary>
    /// <returns>Deve retornar 0,1 ou -1</returns>
    int SelectedCharacter();

    /// <summary>
    /// Método responsável por retornar direcao de movimento do jogador.
    /// </summary>
    /// <returns></returns>
    Vector3 Direction();

    /// <summary>
    /// Método responsável por retornar input de disparo.
    /// </summary>
    /// <returns></returns>
    bool Fire();
}