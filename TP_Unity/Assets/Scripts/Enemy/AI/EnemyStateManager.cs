using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    public EnemyBaseState currentState;

    [field: SerializeField] public EnemyIdleState idleState { get; private set; } = new EnemyIdleState();
    [field: SerializeField] public EnemyPatrolState patrolState { get; private set; } = new EnemyPatrolState();
    [field: SerializeField] public EnemyPursuitState pursuitState { get; private set; } = new EnemyPursuitState();
    [field: SerializeField] public EnemyAttackState attackState { get; private set; } = new EnemyAttackState();

    [field: SerializeField] public Animator animator { get; private set; }
    [HideInInspector] public NavMeshAgent navMeshAgent { get; private set; }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void Start()
    {
        SwitchState(patrolState);
    }

    private void Update()
    {
        currentState.UpdateState(this);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            currentState.OnCollisionEnter(this);
        }
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
