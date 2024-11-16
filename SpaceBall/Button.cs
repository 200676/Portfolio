using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Startscreen");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Back()
    {
        SceneManager.LoadScene("Startscreen");
    }
}
