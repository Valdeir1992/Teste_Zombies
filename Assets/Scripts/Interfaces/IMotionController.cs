/// <summary>
/// Interface responsável definir o gerenciamento de movimento do personagem.
/// </summary>
public interface IMotionController:IConfigurable
{
    /// <summary>
    /// Método utilizado para restrigir movimentacao do personagem.
    /// </summary>
    /// <param name="ative">True para que o personagem passa movimentar</param>
    void CanMove(bool ative);
}