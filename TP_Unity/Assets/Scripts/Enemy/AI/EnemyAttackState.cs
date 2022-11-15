using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager stateManager)
    {
        Debug.Log($"EnterState : {this}");
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadSceneAsync("EndScene");
    }

    public override void UpdateState(EnemyStateManager stateManager)
    {
        
    }

    public override void OnCollisionEnter(EnemyStateManager stateManager)
    {
        
    }
}