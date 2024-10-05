using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
       
    }

    public void AccessLevel1()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
