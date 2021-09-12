/// <summary>
/// Interface responsável por definir o gerenciamento da vida do personagem
/// </summary>
public interface ILifeController : IConfigurable
{
    float CurrentLife
    {
        get;
    }
    /// <summary>
    /// Método responsável por aplicar dano no personagem
    /// </summary>
    /// <param name="amount"></param>
    void TakeDamage(float amount);
}