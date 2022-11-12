using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager stateManager)
    {
        Debug.Log($"EnterState : {this}");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(scene.name);
    }

    public override void UpdateState(EnemyStateManager stateManager)
    {
        
    }

    public override void OnCollisionEnter(EnemyStateManager stateManager)
    {
        
    }
}