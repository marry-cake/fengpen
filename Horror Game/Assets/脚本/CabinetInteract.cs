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
    [Header("上锁抽屉图")]
    public Image drawerImg;
    [Header("解锁后打开抽屉图")]
    public Sprite openDrawerSprite;
    [Header("抽屉点击按钮（解锁后禁用）")]
    public Button drawerBtn;

    private bool panelOpen = false;
    public bool drawerUnlocked = false;

    void Start()
    {
        cabinetPanel.SetActive(false);
        lockPanel.SetActive(false);
        // 关闭按钮全程可点击，不受解锁状态影响
        closeCabinetBtn.onClick.AddListener(CloseCabinet);
    }

    // 点击场景柜子，打开柜子面板
    void OnMouseDown()
    {
        if (panelOpen) return;
        panelOpen = true;
        cabinetPanel.SetActive(true);
        RefreshDrawerState();
    }

    // 刷新抽屉状态
    void RefreshDrawerState()
    {
        lockPanel.SetActive(false);
        if (drawerUnlocked)
        {
            // 切换为打开的抽屉图片
            drawerImg.sprite = openDrawerSprite;
            // 抽屉按钮失效，不能再点出密码
            drawerBtn.interactable = false;
            // 关闭按钮保持可点击，不受影响
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
        if (drawerUnlocked) return;
        lockPanel.SetActive(true);
    }

    // 密码正确，解锁抽屉
    public void UnlockDrawer()
    {
        if (drawerUnlocked) return;
        drawerUnlocked = true;
        lockPanel.SetActive(false);
        drawerImg.sprite = openDrawerSprite;
        // 抽屉按钮禁用
        drawerBtn.interactable = false;
        // 关闭按钮依旧可用
        closeCabinetBtn.interactable = true;
    }

    // 关闭整个柜子面板（任何状态都能触发）
    public void CloseCabinet()
    {
        panelOpen = false;
        cabinetPanel.SetActive(false);
        lockPanel.SetActive(false);
    }
}