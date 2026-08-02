using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DialogSwitch : MonoBehaviour
{
    [Header("所有面板按顺序拖入数组")]
    public GameObject[] dialogPanels;
    [Header("全部面板播放完毕，点击跳转的【场景名字】")]
    public string nextSceneName;

    private int currentIndex = 0;
    private TypeWriter typeWriter;
    private bool hasTextContent = false;

    void Start()
    {
        foreach (GameObject panel in dialogPanels)
        {
            if (panel != null)
            {
                panel.SetActive(false);
                VideoPlayer vp = panel.GetComponentInChildren<VideoPlayer>();
                if (vp != null) vp.Stop();
            }
        }
        if (dialogPanels.Length > 0)
            OpenPanel(0);
    }

    void Update()
    {
        bool dialogIsOpen = false;
        foreach (GameObject panel in dialogPanels)
        {
            if (panel != null && panel.activeSelf)
            {
                dialogIsOpen = true;
                break;
            }
        }
        if (!dialogIsOpen) return;

        if (Input.GetMouseButtonDown(0))
        {
            // 还有文字在打字：一键显示全部文字
            if (hasTextContent && !typeWriter.isFinish)
            {
                typeWriter.ShowAllText();
            }
            else
            {
                GoNext();
            }
        }
    }

    void OpenPanel(int index)
    {
        currentIndex = index;
        GameObject nowPanel = dialogPanels[index];
        nowPanel.SetActive(true);
        hasTextContent = false;

        // 自动播放面板视频
        VideoPlayer vp = nowPanel.GetComponentInChildren<VideoPlayer>();
        if (vp != null) vp.Play();

        // 读取文字打字
        Text txt = nowPanel.GetComponentInChildren<Text>();
        if (txt != null)
        {
            typeWriter = txt.GetComponent<TypeWriter>();
            if (typeWriter != null)
            {
                hasTextContent = true;
                typeWriter.StartType(txt.text);
            }
        }
    }

    void GoNext()
    {
        // 关闭当前面板、停止视频
        GameObject curPanel = dialogPanels[currentIndex];
        VideoPlayer curVp = curPanel.GetComponentInChildren<VideoPlayer>();
        if (curVp != null) curVp.Stop();
        curPanel.SetActive(false);

        // 判断是不是最后一个面板
        if (currentIndex >= dialogPanels.Length - 1)
        {
            // 最后一页点击 → 切换场景
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            return;
        }

        // 不是最后一页，打开下一个面板
        OpenPanel(currentIndex + 1);
    }
}