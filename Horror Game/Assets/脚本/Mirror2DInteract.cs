using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Mirror2DInteract : MonoBehaviour
{
    [Header("视频播放器组件（必须拖拽赋值）")]
    public VideoPlayer mirrorVideo;
    [Header("承载视频的RawImage")]
    public RawImage videoCanvas;
    [Header("退出按钮")]
    public Button closeBtn;
    [Header("看完后显示的照片面板")]
    public RawImage finalImgUI;
    [Header("照片贴图素材")]
    public Texture2D finalTex;

    private bool watchedVideo = false;
    private bool panelActive = false;

    void Start()
    {
        // 开局全部隐藏界面
        videoCanvas.gameObject.SetActive(false);
        finalImgUI.gameObject.SetActive(false);
        closeBtn.gameObject.SetActive(false);

        if (mirrorVideo != null)
        {
            mirrorVideo.playOnAwake = false;
            mirrorVideo.loopPointReached += OnVideoFinish;
            mirrorVideo.Prepare();
            mirrorVideo.Stop(); // 强制开局停止视频
        }
    }

    // 开始按钮绑定这个函数 OpenMirror
    public void OpenMirror()
    {
        if (panelActive) return;
        panelActive = true;

        if (!watchedVideo)
        {
            videoCanvas.gameObject.SetActive(true);
            finalImgUI.gameObject.SetActive(false);

            if (mirrorVideo != null)
            {
                mirrorVideo.Stop();
                mirrorVideo.time = 0;
                mirrorVideo.Play();
            }
        }
        else
        {
            videoCanvas.gameObject.SetActive(false);
            finalImgUI.texture = finalTex;
            finalImgUI.gameObject.SetActive(true);
            closeBtn.gameObject.SetActive(true);
        }
    }

    // 视频播放完毕触发，增加判断：只有面板打开时才弹出按钮
    void OnVideoFinish(VideoPlayer video)
    {
        // 关键判断：面板没打开时，不执行弹出按钮
        if (!panelActive) return;
        watchedVideo = true;
        closeBtn.gameObject.SetActive(true);
    }

    // 退出按钮绑定：ClosePanel
    public void ClosePanel()
    {
        panelActive = false;
        videoCanvas.gameObject.SetActive(false);
        finalImgUI.gameObject.SetActive(false);
        closeBtn.gameObject.SetActive(false);
        if (mirrorVideo != null) mirrorVideo.Stop(); // 关闭面板立刻停止视频
    }
}