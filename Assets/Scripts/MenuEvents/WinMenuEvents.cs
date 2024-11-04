using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuEvents : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GoMenu()
    {
        Player.player = null;
        Destroy(GameObject.Find("Player"));
        GameManager.gameManager = null;
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene("MainMenu");
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
        Application.Quit();
    }
}
