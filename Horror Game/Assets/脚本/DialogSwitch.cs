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
    private TypeWriter1 typeWriter;
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
            if (hasTextContent && typeWriter != null && !typeWriter.isFinish)
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
        // ?【修复】先把全部面板关闭！原来漏掉这一步
        foreach (GameObject p in dialogPanels)
        {
            if (p != null) p.SetActive(false);
        }

        currentIndex = index;
        GameObject nowPanel = dialogPanels[index];
        nowPanel.SetActive(true);
        hasTextContent = false;
        typeWriter = null;

        // 自动播放面板视频
        VideoPlayer vp = nowPanel.GetComponentInChildren<VideoPlayer>();
        if (vp != null) vp.Play();

        // 读取文字打字
        Text txt = nowPanel.GetComponentInChildren<Text>();
        Debug.Log($"【OpenPanel】当前面板:{nowPanel.name}，是否找到Text:{txt != null}");
        if (txt != null)
        {
            typeWriter = txt.GetComponent<TypeWriter1>();
            Debug.Log($"【OpenPanel】是否拿到TypeWriter1：{typeWriter != null}");
            if (typeWriter != null)
            {
                hasTextContent = true;
                // 读取Text上写死的文本，然后清空UI原始文字
                string content = txt.text;
                txt.text = "";
                typeWriter.StartType(content);
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