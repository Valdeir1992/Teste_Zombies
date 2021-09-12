/// <summary>
/// Interface responsável por definir acoes da hud.
/// </summary>
public interface IHudController : IConfigurable
{
    /// <summary>
    /// Método responsável por exibir alteracoes nos valores de vida do personagem.
    /// </summary>
    /// <param name="amount">Quantidade de vida restante do personagem</param>
    void TakeDamage(float amount);
}