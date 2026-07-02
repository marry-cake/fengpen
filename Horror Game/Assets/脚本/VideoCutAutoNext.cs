using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoCutAutoNext : MonoBehaviour
{
    [Header("当前场景的剧情视频播放器")]
    public VideoPlayer cutSceneVideo;
    [Header("视频播放完跳转【第三个场景】名称")]
    public string targetSceneName;

    void Start()
    {
        // 绑定视频播放完成的监听事件
        cutSceneVideo.loopPointReached += OnVideoPlayEnd;
    }

    // 视频完整播放结束后自动运行
    void OnVideoPlayEnd(VideoPlayer vp)
    {
        // 可自定义延迟跳转，这里延迟0.5秒过渡
        Invoke(nameof(SwitchToNextScene), 0.5f);
    }

    void SwitchToNextScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}