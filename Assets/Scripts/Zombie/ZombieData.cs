using UnityEngine;

/// <summary>
/// Script responsáveñ por armazenar dados dos zombies
/// </summary>
[CreateAssetMenu(menuName ="Prototipo/Data/Zombie")]
public class ZombieData : ScriptableObject, IEnemyData
{
    [SerializeField] private float _damage;
    [SerializeField] private float _motionSpeed;
    [SerializeField] private float _lifeMax;
    [SerializeField] private float _cd;
    [SerializeField] private int _points;
    public float Damage => _damage;

    public float MotionSpeed => _motionSpeed;

    public float LifeMax => _lifeMax;

    public float CD => _cd;

    public int Points { get => _points; }
}
