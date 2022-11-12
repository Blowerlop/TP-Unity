using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager stateManager);
    public abstract void UpdateState(EnemyStateManager stateManager);
    public abstract void OnCollisionEnter(EnemyStateManager stateManager);
}