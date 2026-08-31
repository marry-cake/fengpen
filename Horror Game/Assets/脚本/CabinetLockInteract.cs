using UnityEngine;
using UnityEngine.UI;

public class CabinetLockInteract : MonoBehaviour
{
    [Header("柜子总面板")]
    public GameObject cabinetPanel;
    [Header("关闭柜子按钮（永久可用）")]
    public Button closeCabinetBtn;
    [Header("密码锁整套面板")]
    public GameObject lockPanel;
    [Header("上锁抽屉图")]
    public Image drawerImg;
    [Header("解锁后打开抽屉图")]
    public Sprite openDrawerSprite;
    [Header("抽屉点击按钮（解锁前点它出密码）")]
    public Button drawerBtn;
    [Header("解锁完成后，点击抽屉图片跳转的Panel2")]
    public GameObject panel2;

    private bool panelOpen = false;

    void Start()
    {
        if (cabinetPanel != null) cabinetPanel.SetActive(false);
        if (lockPanel != null) lockPanel.SetActive(false);
        if (panel2 != null) panel2.SetActive(false);

        if (closeCabinetBtn != null)
        {
            closeCabinetBtn.onClick.AddListener(CloseCabinet);
        }
        RefreshDrawerState();
    }

    //点击场景柜子物体
    void OnMouseDown()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;
        if (panelOpen) return;

        panelOpen = true;
        if (cabinetPanel != null) cabinetPanel.SetActive(true);
        RefreshDrawerState();
    }

    void RefreshDrawerState()
    {
        if (lockPanel != null) lockPanel.SetActive(false);
        bool isUnlocked = false;
        if (AllGameGlobal.Global != null)
        {
            isUnlocked = AllGameGlobal.Global.lockUnlocked;
        }

        if (isUnlocked)
        {
            if (drawerImg != null) drawerImg.sprite = openDrawerSprite;
            if (drawerBtn != null) drawerBtn.interactable = false;
        }
        else
        {
            if (drawerBtn != null) drawerBtn.interactable = true;
        }
    }

    //点抽屉按钮，弹出密码面板（解锁前可用）
    public void ShowLock()
    {
        if (AllGameGlobal.Global == null || AllGameGlobal.Global.lockUnlocked) return;
        if (lockPanel != null) lockPanel.SetActive(true);
    }

    //密码正确，解锁抽屉，不跳转panel2
    public void UnlockDrawer()
    {
        if (AllGameGlobal.Global == null || AllGameGlobal.Global.lockUnlocked) return;
        AllGameGlobal.Global.lockUnlocked = true;
        AllGameGlobal.Global.SaveLock();

        if (lockPanel != null) lockPanel.SetActive(false);
        if (drawerImg != null) drawerImg.sprite = openDrawerSprite;
        if (drawerBtn != null) drawerBtn.interactable = false;
    }

    public void ClickOpenedDrawerImage()
    {
        if (AllGameGlobal.Global == null || !AllGameGlobal.Global.lockUnlocked)
        {
            return;
        }
        //关闭柜子UI，打开panel2
        if (cabinetPanel != null) cabinetPanel.SetActive(false);
        panelOpen = false;
        if (panel2 != null) panel2.SetActive(true);
    }

    //关闭柜子面板
    public void CloseCabinet()
    {
        panelOpen = false;
        if (cabinetPanel != null) cabinetPanel.SetActive(false);
        if (lockPanel != null) lockPanel.SetActive(false);
    }
}