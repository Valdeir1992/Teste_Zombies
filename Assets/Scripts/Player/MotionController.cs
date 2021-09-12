using UnityEngine;

/// <summary>
/// Script responsável por gerenciar a movimentacao do personagem.
/// </summary>
public class MotionController : MonoBehaviour, IMotionController
{
    #region PRIVATE VARIABLES

    private ICharacterMediator _player;

    private CharacterController _controller;

    private IInput _input;

    private Vector3 _direction;

    private bool _canMove = false;
    #endregion

    #region UNITY METHODS
    private void Awake()
    { 
        _input = DatafactoryPlayers.Instance.GetInputs();

        _controller = GetComponent<CharacterController>(); 
    }
    private void Start()
    {
        CanMove(true);
    }
    private void Update()
    {
        if (!_player.IsDead)
        { 
            _direction = _input.Direction();
        }
        else
        {
            _direction = Vector3.zero;
        }
    }
    private void FixedUpdate()
    {
        Move(_direction);
    }
    #endregion

    #region OWN METHODS
    public void Configure(ICharacterMediator character)
    {
        _player = character; 
    }

    private void Move(Vector3 direction)
    {
        if (_canMove)
        { 
            Vector3 finalDirection = Camera.main.transform.TransformDirection(direction);

            finalDirection = finalDirection.normalized * _player.Data.MotionSpeed;

            finalDirection.y = 0;

            if(finalDirection.sqrMagnitude > 0)
            {
                _player.Move();
            }
            else
            {
                _player.Idle();
            }

            _controller.SimpleMove(finalDirection);
        } 
    }

    public void CanMove(bool ative)
    {
        _canMove = ative;
    }
    #endregion
}
