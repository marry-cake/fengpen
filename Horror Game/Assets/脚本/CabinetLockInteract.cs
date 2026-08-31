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
    [Header("抽屉点击按钮（解锁后禁用）")]
    public Button drawerBtn;

    private bool panelOpen = false;

    void Start()
    {
        cabinetPanel.SetActive(false);
        lockPanel.SetActive(false);
        closeCabinetBtn.onClick.AddListener(CloseCabinet);
        // 启动读取全局解锁状态
        RefreshDrawerState();
    }

    // 点击场景柜子，打开柜子面板 + 防UI穿透
    void OnMouseDown()
    {
        // 拦截UI穿透
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;

        if (panelOpen) return;
        panelOpen = true;
        cabinetPanel.SetActive(true);
        RefreshDrawerState();
    }

    // 刷新抽屉状态：优先读取全局存档状态
    void RefreshDrawerState()
    {
        lockPanel.SetActive(false);
        bool isUnlocked = AllGameGlobal.Global.lockUnlocked;
        if (isUnlocked)
        {
            drawerImg.sprite = openDrawerSprite;
            drawerBtn.interactable = false;
            closeCabinetBtn.interactable = true;
        }
        else
        {
            drawerBtn.interactable = true;
        }
    }

    // 点击抽屉按钮，弹出密码面板
    public void ShowLock()
    {
        if (AllGameGlobal.Global.lockUnlocked) return;
        lockPanel.SetActive(true);
    }

    // 密码正确，解锁抽屉，同步全局存档状态
    public void UnlockDrawer()
    {
        if (AllGameGlobal.Global.lockUnlocked) return;
        // 全局标记解锁+保存
        AllGameGlobal.Global.lockUnlocked = true;
        AllGameGlobal.Global.SaveLock();

        lockPanel.SetActive(false);
        drawerImg.sprite = openDrawerSprite;
        drawerBtn.interactable = false;
        closeCabinetBtn.interactable = true;
    }

    // 关闭整个柜子面板
    public void CloseCabinet()
    {
        panelOpen = false;
        cabinetPanel.SetActive(false);
        lockPanel.SetActive(false);
    }
}