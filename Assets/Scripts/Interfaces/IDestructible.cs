/// <summary>
/// Interface responsável por definir o recebimento de dano em personagens, zombies e objetos
/// </summary>
public interface IDestructible
{
    /// <summary>
    /// Método responsavel por aplicar dano.
    /// </summary>
    /// <param name="damage">Quantidade de dano</param>
    void TakeDamage(float damage);
}