using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch1 : MonoBehaviour
{
    public string targetSceneName = "game1";

    void OnMouseDown()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}