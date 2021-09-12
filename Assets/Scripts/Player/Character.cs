using System.Collections; 
using UnityEngine;

/// <summary>
/// Script responsável por definir base dos personagens. 
/// </summary>
public abstract class Character : MonoBehaviour, ICharacterMediator
{
    #region PROTECTED VARIABLES

    protected IMotionController _motionController;

    protected IMouseController _mouseController;

    protected IAnimationController _AnimationController;

    protected IWeaponController _weaponController;

    protected ILifeController _lifeController;

    protected IHudController _hudController;
    #endregion

    #region PRIVATE VARIABLES

    private bool _isDead = false; 

    [SerializeField] private CharacterData _data;
    #endregion

    #region PUBLIC VARIABLES
    public bool IsDead { get => _isDead; }  

    public ICharacterData Data { get => _data; }

    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _mouseController = GetComponent<IMouseController>();

        _AnimationController = GetComponent<IAnimationController>();

        _weaponController = GetComponent<IWeaponController>();

        _hudController = GetComponent<IHudController>();

        _mouseController.Configure(this);

        _AnimationController.Configure(this);

        _weaponController.Configure(this);

        _hudController.Configure(this);
    }
    #endregion

    #region OWN METHODS
    public void Fire()
    {
        _AnimationController.Fire();
    } 
    public void StopFire()
    {
        _AnimationController.StopFire();
    }
    public void Install(IMotionController motion, ILifeController life )
    {
        _motionController = motion;

        _lifeController = life;

        _motionController.Configure(this);

        _lifeController.Configure(this);
    }

    public void Move()
    {
        _AnimationController.Walk();
    }

    public void Idle()
    {
        _AnimationController.Idle();
    }

    public void TakeDamage(float amount)
    {
        _lifeController.TakeDamage(amount);

        _hudController.TakeDamage(_lifeController.CurrentLife);
    }

    public void Dead()
    {
        _isDead = true;

        StartCoroutine(Coroutine_Dead());
    }
    #endregion

    #region COROUTINES
    private IEnumerator Coroutine_Dead()
    { 
        _AnimationController.Dead();

        yield return new WaitForSeconds(2);

        Datafactory.Instance.GetGameplayerComponent().GameOver();
    }
    #endregion
}
