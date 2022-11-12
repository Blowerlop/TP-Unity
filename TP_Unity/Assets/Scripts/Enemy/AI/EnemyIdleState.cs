using UnityEngine;

[System.Serializable]
public class EnemyIdleState : EnemyBaseState
{
    [SerializeField] private float _updateTimer = 2.0f;
    private float _currentTimer;
    
    public override void EnterState(EnemyStateManager stateManager)
    {
        Debug.Log($"EnterState : {this}");
        _currentTimer = _updateTimer;
        stateManager.animator.SetTrigger("Idling");
    }

    public override void UpdateState(EnemyStateManager stateManager)
    {
        if (_currentTimer < 0)
        {
            stateManager.SwitchState(stateManager.patrolState);
        }
        else
        {
            _currentTimer -= Time.deltaTime;
        }

    }

    public override void OnCollisionEnter(EnemyStateManager stateManager)
    {
        
    }
}