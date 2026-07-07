using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitchBtn : MonoBehaviour
{
    [Header("Ìø×ª³¡¾°Ãû³Æ")]
    public string targetScene = "game1";
    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SwitchScene);
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}