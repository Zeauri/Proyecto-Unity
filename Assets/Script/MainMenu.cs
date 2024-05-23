using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() 
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Main()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Quitegame()
    {
        Application.Quit();
    }
}
