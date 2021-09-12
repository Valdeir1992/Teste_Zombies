/// <summary>
/// Interface responsável por definir camada de dados dos personagens.
/// </summary>
public interface ICharacterData
{
    float MotionSpeed
    {
        get;
    } 
    float Damage
    {
        get;
    }
    float CD 
    { 
        get;
    }
    float LifeMax { get; }
}
