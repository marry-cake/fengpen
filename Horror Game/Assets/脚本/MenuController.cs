using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("循环播放的封面视频组件")]
    public VideoPlayer menuVideo;
    [Header("开始游戏按钮")]
    public Button startGameBtn;
    [Header("退出游戏按钮")]
    public Button quitBtn;
    [Header("游戏主场景名称（填你关卡场景名）")]
    public string gameScene;

    void Start()
    {
        // 绑定按钮点击事件
        startGameBtn.onClick.AddListener(LoadGameScene);
        quitBtn.onClick.AddListener(QuitGame);
    }

    // 点击开始，切换下一个场景
    void LoadGameScene()
    {
        menuVideo.Stop();
        SceneManager.LoadScene(gameScene);
    }

    // 点击退出，关闭游戏
    void QuitGame()
    {
        // 编辑器内提示，打包后直接退出
        if (Application.isEditor)
        {
            Debug.Log("编辑器中无法退出，打包运行才可生效");
        }
        else
        {
            menuVideo.Stop();
            Application.Quit();
        }
    }
}