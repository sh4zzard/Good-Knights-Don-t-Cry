using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Options ()
    {
        SceneManager.LoadScene(9);
    }
    public void QuitGame ()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
