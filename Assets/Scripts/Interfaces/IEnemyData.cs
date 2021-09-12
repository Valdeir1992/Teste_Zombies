/// <summary>
/// Interface responsável por definir camada de dados dos inimigos.
/// </summary>
public interface IEnemyData
{
    float Damage
    {
        get;
    }

    float MotionSpeed
    {
        get;
    }

    float LifeMax
    {
        get;
    }

    float CD
    {
        get;
    }
}