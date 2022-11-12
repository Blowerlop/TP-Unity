using UnityEngine;

[System.Serializable]
public class EnemyPatrolState : EnemyBaseState
{
    [SerializeField] private Transform[] patrolPoints;

    public override void EnterState(EnemyStateManager stateManager)
    {
        Debug.Log($"EnterState : {this}");
        
        stateManager.navMeshAgent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
        stateManager.animator.SetTrigger("Walking");

    }

    public override void UpdateState(EnemyStateManager stateManager)
    {
        if (Vector3.Distance(stateManager.transform.position, stateManager.navMeshAgent.destination) <= 1f)
        {
            stateManager.SwitchState(stateManager.idleState);
        }
    }

    public override void OnCollisionEnter(EnemyStateManager stateManager)
    {
        
    }
}
