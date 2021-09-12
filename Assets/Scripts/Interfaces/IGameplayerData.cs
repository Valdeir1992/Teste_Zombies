/// <summary>
/// Interface responsável pelo gerenciamento da camada de dados.
/// </summary>
public interface IGameplayerData
{
    int SelectedCharacter { get; }

    /// <summary>
    /// Método para setar o personagem selecionado.
    /// </summary>
    /// <param name="value"></param>
    void SetCharacter(int value);
}