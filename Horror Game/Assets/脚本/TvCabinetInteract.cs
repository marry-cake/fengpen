using UnityEngine;

public class TvCabinetInteract : MonoBehaviour
{
    [Header("UI面板")]
    public GameObject panel_TvCabinet;
    public GameObject lockPanel;
    public GameObject successPanel;

    private const string SAVE_KEY_BOX_UNLOCK = "BoxUnlocked";
    [HideInInspector] public bool isBoxUnlocked;

    void Start()
    {
        isBoxUnlocked = PlayerPrefs.GetInt(SAVE_KEY_BOX_UNLOCK, 0) == 1;
        panel_TvCabinet.SetActive(false);
        lockPanel.SetActive(false);
        successPanel.SetActive(false);
        Debug.Log($"读取解锁状态：{isBoxUnlocked}");
    }

    //===【透明Button_TvCan的OnClick调用这个函数】===
    public void ClickTvCanArea()
    {
        CloseAllPanel();
        if (isBoxUnlocked)
        {
            successPanel.SetActive(true);
        }
        else
        {
            panel_TvCabinet.SetActive(true);
        }
    }

    //电视柜面板内部按钮调用
    public void OpenLockPanel()
    {
        panel_TvCabinet.SetActive(false);
        lockPanel.SetActive(true);
    }

    public void CloseAllPanel()
    {
        panel_TvCabinet.SetActive(false);
        lockPanel.SetActive(false);
        successPanel.SetActive(false);
    }
}