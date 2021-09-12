/// <summary>
/// Interface responsável por implementar o padrao mediator para os personagens.
/// </summary>
public interface ICharacterMediator:IDestructible
{
    ICharacterData Data
    {
        get;
    }

    bool IsDead
    {
        get;
    }
    /// <summary>
    /// Método de callback para disparo.
    /// </summary>
    void Fire();
    /// <summary>
    /// Método de callback para movimento.
    /// </summary>
    void Move();
    /// <summary>
    /// Método responsável por configurar movimento e vida do personagem.
    /// </summary>
    /// <remarks>Esse método foi nescessario para implementacao de código para o modo multiplayer</remarks>
    void Install(IMotionController motion, ILifeController life);
    /// <summary>
    /// Método de callback para parada de movimento.
    /// </summary>
    void Idle();
    /// <summary>
    /// Método de callback para parada de disparo.
    /// </summary>
    void StopFire();
    /// <summary>
    /// Método de callback para morte.
    /// </summary>
    void Dead();
}