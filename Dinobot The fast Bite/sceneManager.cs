using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : MonoBehaviour
{
    private bool isPaused;
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private GameObject pauseAim;
    [SerializeField] private GameObject pauseBulletSpawn;

    
    private void Start()
    {
        PlayerMovement.FindAnyObjectByType<PlayerMovement>();
      
       
        if (playerMovement == isPaused)
        {
            Time.timeScale = 1f;
        }
       
       pauseMenuCanvas.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
                Debug.Log("unpause");
            }

            else 
            {
                Pause();
                Debug.Log("pause");
            }

        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game.Beta");
    }
    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartToGame()
    {
        SceneManager.LoadScene("Game.Beta");
    }
    
    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        pauseBulletSpawn.SetActive(false);
        pauseAim.SetActive(false);
    }
    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        pauseBulletSpawn.SetActive(true);
        pauseAim.SetActive(true);
        
    }
    public void Quit()
    {
        Application.Quit();

    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver"); 
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Game.Beta");
    }
   
}
