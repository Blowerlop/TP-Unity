using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
        Cursor.lockState = CursorLockMode.Locked;
    }

    


    public void Quit()
    {
        Application.Quit();
    }
}
