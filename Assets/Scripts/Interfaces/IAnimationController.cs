/// <summary>
/// Interface responsável definir o gerenciamento das animacoes dos personagens.
/// </summary>
public interface IAnimationController:IConfigurable
{
    /// <summary>
    /// Método responsável por ativar animacao de movimentacao.
    /// </summary>
    void Walk();

    /// <summary>
    /// Método responsável por ativar animacao de disparo.
    /// </summary>
    void Fire();

    /// <summary>
    /// Método responsável por desativar animacao de disparo.
    /// </summary>
    void StopFire();
    /// <summary>
    /// Método responsável por ativar animacao de ocioso.
    /// </summary>
    void Idle();
    /// <summary>
    /// Método responsável por ativar animacao de morte.
    /// </summary>
    void Dead();
}