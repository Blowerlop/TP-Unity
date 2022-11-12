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
    }

    public override void UpdateState(EnemyStateManager stateManager)
    {
        stateManager.navMeshAgent.SetDestination(targetPostion);
    }

    public override void OnCollisionEnter(EnemyStateManager stateManager)
    {
        stateManager.SwitchState(stateManager.attackState);
    }
}