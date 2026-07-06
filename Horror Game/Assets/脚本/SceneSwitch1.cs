using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch1 : MonoBehaviour
{
    public string targetSceneName = "game3";

    void OnMouseDown()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}