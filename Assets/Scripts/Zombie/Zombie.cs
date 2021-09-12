using System; 
using UnityEngine;
using UnityEngine.AI; 

/// <summary>
/// Script responsável por gerenciar os zombies
/// </summary>
public class Zombie : MonoBehaviour, IDestructible
{
    #region PRIVATE VARIABLES

    private NavMeshAgent _agent;

    private Animator _anim;

    private float _currentLife;  

    private Transform _player;

    private float _timeElapsed; 

    [SerializeField] private ZombieData _data;
    #endregion

    #region PUBLIC VARIABLES

    public Action<Zombie> CallBackDead;

    public ZombieData Data { get => _data; }
    #endregion

    #region UNITY METHODS

    private void Awake()
    {  
        _agent = GetComponent<NavMeshAgent>();

        _anim = GetComponent<Animator>(); 
  
        _currentLife = _data.LifeMax; 
    }

    private void Start()
    {
        _player = FindObjectOfType<Character>().transform;

        _agent.speed = _data.MotionSpeed; 

        _agent.SetDestination(_player.position); 

        InvokeRepeating("Move", 0, 0.1f);
    }
    private void Update()
    {
        Attack(); 
        if(_timeElapsed < _data.CD)
        {
            _timeElapsed += Time.deltaTime;
        }
    }
    #endregion

    #region OWN METHODS
    private void Move()
    {
        if(!UnityEngine.Object.ReferenceEquals(_player,null))
        { 
            _agent.SetDestination(_player.position);
        } 
    }

    public void Attack()
    {
        float distanceSqr = Vector2.SqrMagnitude(new Vector2(_player.position.x, _player.position.z) - new Vector2(transform.position.x,transform.position.z));

        if(distanceSqr <= _agent.stoppingDistance * _agent.stoppingDistance)
        {
            if(_timeElapsed >= _data.CD)
            {
                _timeElapsed = 0;

                _anim.SetBool("Attack", true); 

                _agent.isStopped = true;

                _player.GetComponent<ICharacterMediator>().TakeDamage(_data.Damage);

                Invoke("MoveAgain", 0.5f);
            } 
        }
    }
    public void TakeDamage(float damage)
    { 
        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            CallBackDead?.Invoke(this);  
        }
    }

    private void MoveAgain()
    {
        _agent.isStopped = false;

        _anim.SetBool("Attack", false);
    }
    #endregion
}
