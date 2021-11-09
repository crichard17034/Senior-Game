using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{

    public void Teleport(string location)
    {
        SceneManager.LoadScene(location);
    }
}
