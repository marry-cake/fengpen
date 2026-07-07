using UnityEngine;
using UnityEngine.Video;

public class GiftClickOpenVideo : MonoBehaviour
{
    [Header("Inspector面板拖拽赋值")]
    //存放视频的UI面板，场景初始状态把这个面板取消勾选隐藏
    public GameObject videoUIPanel;
    //挂载了VideoPlayer组件的物体
    public VideoPlayer giftVideoPlayer;

    void Start()
    {
        //初始化：确保游戏一开始面板隐藏、视频不会预播放
        videoUIPanel.SetActive(false);
        giftVideoPlayer.playOnAwake = false;
        //播放结束自动关闭弹窗
        giftVideoPlayer.loopPointReached += CloseVideoPanel;
    }

    //鼠标点击礼物（场景2D物体适用该方法，前提礼物身上添加BoxCollider2D碰撞体）
    private void OnMouseDown()
    {
        OpenVideoPanelFunc();
    }

    void OpenVideoPanelFunc()
    {
        //防止重复点击多次叠加播放
        if (videoUIPanel.activeSelf) return;

        videoUIPanel.SetActive(true);
        giftVideoPlayer.Stop();
        giftVideoPlayer.Play();
    }

    //视频播放结束回调，关闭UI面板
    void CloseVideoPanel(VideoPlayer player)
    {
        videoUIPanel.SetActive(false);
    }

    //可选：跳过按钮绑定这个方法，Inspector把按钮OnClick事件指向该函数
    public void SkipPlay()
    {
        giftVideoPlayer.Stop();
        videoUIPanel.SetActive(false);
    }

    //销毁时解绑事件，规避内存泄漏
    private void OnDestroy()
    {
        giftVideoPlayer.loopPointReached -= CloseVideoPanel;
    }
}