/// <summary>
/// Interface responsável por definir a configuracao inicial do padrao mediator.
/// </summary>
public interface IConfigurable
{
    /// <summary>
    /// Método responsavel por injetar dependencia nos objetos.
    /// </summary>
    /// <param name="character"></param>
    void Configure(ICharacterMediator character);
}