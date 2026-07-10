using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitchBtn : MonoBehaviour
{
    [Header("要跳转的场景名称（和Build Settings里一致）")]
    public string targetSceneName;

    // 改成 public，面板才能看见
    public void SwitchScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}