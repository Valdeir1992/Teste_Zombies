using UnityEngine;
/// <summary>
/// Script responsável por gerenciar a cada de dados do personagem.
/// </summary>
[CreateAssetMenu(menuName = "Prototipo/Data/Character")]
public sealed class CharacterData : ScriptableObject, ICharacterData
{
    [SerializeField] private float _motionSpeed;

    [SerializeField] private float _damage;

    [SerializeField] private float _cd;

    [SerializeField] private float _lifeMax;
    public float MotionSpeed => _motionSpeed; 
    public float Damage => _damage; 
    public float CD => _cd; 
    public float LifeMax => _lifeMax;
}