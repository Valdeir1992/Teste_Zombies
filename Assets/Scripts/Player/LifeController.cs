using UnityEngine;

/// <summary>
/// Script responsável por gerenciar a vida do jogador.
/// </summary>
public class LifeController : MonoBehaviour, ILifeController
{
    #region PRIVATE VARIABLES
    private ICharacterMediator _player;

    private float _currentLife;
    #endregion

    #region PUBLIC VARIABLES
    public float CurrentLife { get => _currentLife; }
    #endregion

    #region OWN METHODS
    public void Configure(ICharacterMediator character)
    {
        _player = character;
        _currentLife = character.Data.LifeMax;
    }

    public void TakeDamage(float amount)
    {
        _currentLife -= amount;

        if(_currentLife <= 0)
        {
            _player.Dead();
        }
    }
    #endregion
}