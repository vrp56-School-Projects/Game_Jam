using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("OpeningScene");
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("StartMenu");
    }

    
}

