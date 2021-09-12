using UnityEngine;

/// <summary>
/// Script responsável por controlar personagens do menu inicial.
/// </summary>
public class CharacterMenu : MonoBehaviour,ICharacterMenu
{
    #region PRIVATE VARIABLES
    private Animator _anim;

    [SerializeField] private int _id;
    #endregion

    #region PUBLIC VARIABLES
    public int Id { get => _id;}
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    #endregion

    #region OWN METHODS 
    public void Execute()
    {
        _anim.Play("Idle");
    }
    #endregion
}
