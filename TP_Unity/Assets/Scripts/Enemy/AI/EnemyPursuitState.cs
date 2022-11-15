using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class EnemyPursuitState : EnemyBaseState
{
    public Vector3 targetPostion;
    public bool hear;
    public bool see;
    
    public override void EnterState(EnemyStateManager stateManager)
    {
        Debug.Log($"EnterState : {this}");
        stateManager.animator.SetTrigger("Walking");
    }

    public override void UpdateState(EnemyStateManager stateManager)
    {
        stateManager.navMeshAgent.SetDestination(targetPostion);

        if (Vector3.Distance(stateManager.transform.position, stateManager.navMeshAgent.destination) <= 0.1f)
        {
            stateManager.SwitchState(stateManager.patrolState);
        }
    }

    public override void OnCollisionEnter(EnemyStateManager stateManager)
    {
        stateManager.SwitchState(stateManager.attackState);
    }
}