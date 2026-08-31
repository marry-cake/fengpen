using UnityEngine;

public class TVTrigger2D : MonoBehaviour
{
    [Header("UI面板")]
    public GameObject panel_TvCabinet;   //打开电视柜
    public GameObject panel_Lock;        //锁面板
    public GameObject panel_OpenBox;     //开盒

    private const string SAVE_TV_UNLOCK = "TvCanUnlocked";
    private int clickStep = 0;

    void Start()
    {
        if (panel_TvCabinet != null) panel_TvCabinet.SetActive(false);
        if (panel_Lock != null) panel_Lock.SetActive(false);
        if (panel_OpenBox != null) panel_OpenBox.SetActive(false);
    }

    private void OnMouseDown()
    {
        //点击到UI就忽略
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;

        bool isUnlocked = PlayerPrefs.GetInt(SAVE_TV_UNLOCK, 0) == 1;
        //已经解锁，直接开【开盒】
        if (isUnlocked)
        {
            HideAllPanels();
            if (panel_OpenBox != null) panel_OpenBox.SetActive(true);
            return;
        }

        //未解锁流程
        if (clickStep == 0)
        {
            HideAllPanels();
            panel_TvCabinet?.SetActive(true);
            clickStep = 1;
        }
        else if (clickStep == 1)
        {
            HideAllPanels();
            panel_Lock?.SetActive(true);
        }
    }

    // ========== 给【确定】按钮绑定这个函数！！ ==========
    public void OnPasswordConfirm()
    {
        //这里：你的LockManager密码判断写在确定按钮那里，密码正确时调用本函数
        PlayerPrefs.SetInt(SAVE_TV_UNLOCK, 1);
        PlayerPrefs.Save();

        HideAllPanels();
        if (panel_OpenBox != null) panel_OpenBox.SetActive(true);
    }

    void HideAllPanels()
    {
        panel_TvCabinet?.SetActive(false);
        panel_Lock?.SetActive(false);
        panel_OpenBox?.SetActive(false);
    }

    //给所有back返回按钮绑定这个
    public void CloseAllUI()
    {
        HideAllPanels();
        clickStep = 0;
    }

    //测试重置，做个按钮调用，方便反复测试密码
    public void ResetSave()
    {
        PlayerPrefs.SetInt(SAVE_TV_UNLOCK, 0);
        PlayerPrefs.Save();
        clickStep = 0;
        HideAllPanels();
    }
}