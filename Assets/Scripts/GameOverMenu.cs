using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame(){
        // Physics.gravity = new Vector3(0, -9.8f, 0);
        SceneManager.LoadScene(2);
    }

    public void HomeButton(){
        // Physics.gravity = new Vector3(0, -9.8f, 0);
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Debug.Log("Quit");
    }
}
