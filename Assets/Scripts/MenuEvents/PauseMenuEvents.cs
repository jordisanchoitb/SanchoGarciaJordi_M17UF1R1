using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuEvents : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnGame();
        }
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("PauseMenu");
        Player.IsPaused = false;
    }

    public void GoMenu()
    {
        Player.player = null;
        Destroy(GameObject.Find("Player"));
        GameManager.gameManager = null;
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene("MainMenu");
        AudioManager.audioManager.PlaySoundEffectLeave();
    }
    public void Replay()
    {       
        Player.player = null;
        Destroy(GameObject.Find("Player"));
        GameManager.gameManager = null;
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        AudioManager.audioManager.PlaySoundEffectLeave();
        Application.Quit();
    }
}

