/// <summary>
/// Interface responsável por definir gerenciamento dos personagens do menu inicial.
/// </summary>
public interface ICharacterMenu
{
    int Id { get; }

    /// <summary>
    /// Método responsavel por executar animacao dos personagens na tela de menu inicial.
    /// </summary>
    void Execute();
}