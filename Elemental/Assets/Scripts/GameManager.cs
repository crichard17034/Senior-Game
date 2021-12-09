using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject databaseSave;

    public void newGame()
    {
        SceneManager.LoadScene(1);

    }
    
    public void continueGame()
    {
        SceneManager.LoadScene(1);
    }

    // takes in a string containing the name of a scene and loads it through SceneManager.
    public void Teleport(string location)
    {
        SceneManager.LoadScene(location);
    }

    public void unlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
