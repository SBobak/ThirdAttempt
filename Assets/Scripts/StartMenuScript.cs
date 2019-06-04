using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You can't escape");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
