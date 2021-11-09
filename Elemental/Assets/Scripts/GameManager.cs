using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{

    // takes in a string containing the name of a scene and loads it through SceneManager.
    public void Teleport(string location)
    {
        SceneManager.LoadScene(location);
    }
}
