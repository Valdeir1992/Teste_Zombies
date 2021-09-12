using UnityEngine;

/// <summary>
/// Classe responsável por controlar animacoes do personagem. 
/// </summary>
public class AnimationController : MonoBehaviour, IAnimationController
{
    #region PRIVATE VARIABLES

    private ICharacterMediator _player;

    private Animator _anim;
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    #endregion

    #region OWN METHHODS
    public void Configure(ICharacterMediator character)
    {
        _player = character;
    }

    public void Fire()
    { 
        _anim.SetBool("Attack", true);
    }

    public void Idle()
    {
        _anim.SetBool("Walk", false);
    }

    public void Walk()
    {
        _anim.SetBool("Walk", true);
    }

    public void StopFire()
    {
        _anim.SetBool("Attack", false);
    }

    public void Dead()
    { 
        _anim.SetBool("Dead", true);

        _anim.SetBool("Attack", false); 
    }
    #endregion
}
