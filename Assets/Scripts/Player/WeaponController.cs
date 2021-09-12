using UnityEngine;

/// <summary>
/// Script responsável por gerenciar as armas do jogo.
/// </summary>
public class WeaponController : MonoBehaviour, IWeaponController
{
    #region PRIVATE VARIABLES

    private ICharacterMediator _player;

    private IInput _input;

    private float _timeElapsed = 1;

    private AudioSource _emissior;
    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        _emissior = GetComponent<AudioSource>();
    }
    #endregion

    #region OWN METHODS
    public void Configure(ICharacterMediator character)
    {
        _player = character;

        _input = DatafactoryPlayers.Instance.GetInputs();
    }

    private void Update()
    {
        if(_timeElapsed <= _player.Data.CD)
        {
            _timeElapsed += Time.deltaTime;
        }
        if (_input.Fire() && !_player.IsDead)  
        {
            Fire();
        }
        else
        {
            _player.StopFire();
        }
    }

    private void Fire()
    {
        if(_timeElapsed >= _player.Data.CD)
        {
            _timeElapsed = 0; 

            _emissior.Play();

            RaycastHit hit;

            Physics.Raycast(transform.position + Vector3.up * 1.4f, transform.forward, out hit);
             
            if(hit.collider != null)
            { 

                if (hit.collider.TryGetComponent(out IDestructible target))
                {
                    target.TakeDamage(_player.Data.Damage);
                }
            } 
        } 
        _player.Fire(); 
    }
    #endregion
}
