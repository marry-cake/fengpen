using UnityEngine;
using UnityEngine.UI;

public class CabinetInteract : MonoBehaviour
{
    [Header("柜子总面板")]
    public GameObject cabinetPanel;
    [Header("关闭柜子按钮（永久可用）")]
    public Button closeCabinetBtn;
    [Header("密码锁整套面板")]
    public GameObject lockPanel;

    [Header("【层级物体】上锁抽屉Image")]
    public Image drawerClosedImg;
    [Header("【层级物体】打开抽屉Image")]
    public Image drawerOpenImg;
    [Header("退出打开抽屉按钮（在打开抽屉界面才显示）")]
    public Button closeOpenDrawerBtn;

    [Header("抽屉点击按钮（解锁后禁用）")]
    public Button drawerBtn;

    [Header("日记本按钮（放在柜子面板内部，叠在打开抽屉图日记本位置）")]
    public Button diaryBtn;
    [Header("日记本UI面板（Canvas下与柜子面板平级）")]
    public GameObject diaryPanel;
    [Header("日记本面板内关闭按钮")]
    public Button closeDiaryBtn;

    private bool panelOpen = false;
    public bool drawerUnlocked = false;

    void Start()
    {
        cabinetPanel.SetActive(false);
        lockPanel.SetActive(false);

        drawerClosedImg.gameObject.SetActive(true);
        drawerOpenImg.gameObject.SetActive(false);
        closeOpenDrawerBtn.gameObject.SetActive(false);
        diaryBtn.gameObject.SetActive(false);
        diaryPanel.SetActive(false);

        closeCabinetBtn.onClick.AddListener(CloseCabinet);
        closeOpenDrawerBtn.onClick.AddListener(ExitOpenDrawer);
        diaryBtn.onClick.AddListener(OpenDiaryPanel);
        closeDiaryBtn.onClick.AddListener(CloseDiaryPanel);
        drawerBtn.onClick.AddListener(ShowLock);
    }

    void OnMouseDown()
    {
        if (panelOpen) return;
        panelOpen = true;
        cabinetPanel.SetActive(true);
        RefreshDrawerState();
    }

    void RefreshDrawerState()
    {
        lockPanel.SetActive(false);
        if (drawerUnlocked)
        {
            drawerClosedImg.gameObject.SetActive(false);
            drawerOpenImg.gameObject.SetActive(true);
            closeOpenDrawerBtn.gameObject.SetActive(true);
            drawerBtn.interactable = false;
            diaryBtn.gameObject.SetActive(true);
        }
        else
        {
            drawerClosedImg.gameObject.SetActive(true);
            drawerOpenImg.gameObject.SetActive(false);
            closeOpenDrawerBtn.gameObject.SetActive(false);
            drawerBtn.interactable = true;
            diaryBtn.gameObject.SetActive(false);
        }
    }

    public void ShowLock()
    {
        if (drawerUnlocked) return;
        lockPanel.SetActive(true);
    }

    public void UnlockDrawer()
    {
        if (drawerUnlocked) return;
        drawerUnlocked = true;
        lockPanel.SetActive(false);

        drawerClosedImg.gameObject.SetActive(false);
        drawerOpenImg.gameObject.SetActive(true);
        closeOpenDrawerBtn.gameObject.SetActive(true);
        drawerBtn.interactable = false;
        diaryBtn.gameObject.SetActive(true);
    }

    public void ExitOpenDrawer()
    {
        drawerClosedImg.gameObject.SetActive(true);
        drawerOpenImg.gameObject.SetActive(false);
        closeOpenDrawerBtn.gameObject.SetActive(false);
        diaryBtn.gameObject.SetActive(false);
        diaryPanel.SetActive(false);
    }

    void OpenDiaryPanel()
    {
        diaryPanel.SetActive(true);
    }

    void CloseDiaryPanel()
    {
        diaryPanel.SetActive(false);
    }

    public void CloseCabinet()
    {
        panelOpen = false;
        cabinetPanel.SetActive(false);
        lockPanel.SetActive(false);
        diaryPanel.SetActive(false);
    }
}