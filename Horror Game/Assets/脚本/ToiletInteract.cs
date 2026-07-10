using UnityEngine;
using UnityEngine.UI;

public class ToiletInteract : MonoBehaviour
{
    [Header("全屏马桶背景图")]
    public RawImage toiletImgUI;
    [Header("马桶关盖贴图")]
    public Texture2D toiletCloseTex;
    [Header("马桶开盖贴图")]
    public Texture2D toiletOpenTex;
    [Header("马桶盖子点击按钮")]
    public Button toiletLidBtn;
    [Header("关闭马桶界面按钮")]
    public Button closeToiletBtn;
    [Header("全局退出场景按钮")]
    public Button exitSceneBtn;
    [Header("提示文字框")]
    public Text tipText;
    public float tipShowTime = 1.5f;
    [Header("马桶内钥匙Image")]
    public GameObject keyUI;

    // 全局标记是否获得螺丝刀，其他脚本赋值 ToiletInteract.HasScrewdriver = true;
    public static bool HasScrewdriver = false;
    private bool panelActive = false;
    private bool lidOpened = false; // 记录水箱是否已经打开
    private bool keyGot = false;    // 记录钥匙是否拾取
    private float tipTimer;

    void Start()
    {
        toiletImgUI.gameObject.SetActive(false);
        closeToiletBtn.gameObject.SetActive(false);
        toiletLidBtn.gameObject.SetActive(false);
        keyUI.SetActive(false);

        if (tipText != null) tipText.gameObject.SetActive(false);
        if (exitSceneBtn != null) exitSceneBtn.interactable = true;
        if (closeToiletBtn != null) closeToiletBtn.onClick.AddListener(CloseToiletPanel);
        if (toiletLidBtn != null) toiletLidBtn.onClick.AddListener(ClickLid);
    }

    void Update()
    {
        // 提示文字倒计时自动隐藏
        if (tipText != null && tipText.gameObject.activeSelf)
        {
            tipTimer -= Time.deltaTime;
            if (tipTimer <= 0)
                tipText.gameObject.SetActive(false);
        }

        // Overlay画布，第三个参数固定null，不用摄像机
        if (panelActive && keyUI.activeSelf && !keyGot && Input.GetMouseButtonDown(0))
        {
            RectTransform keyRect = keyUI.GetComponent<RectTransform>();
            Vector2 mousePos = Input.mousePosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(keyRect, mousePos, null, out Vector2 localPoint))
            {
                Vector2 size = keyRect.sizeDelta / 2f;
                if (Mathf.Abs(localPoint.x) < size.x && Mathf.Abs(localPoint.y) < size.y)
                {
                    PickKey();
                }
            }
        }
    }

    // 点击场景马桶，弹出界面，自动读取水箱状态
    public void OpenToilet()
    {
        if (panelActive) return;
        panelActive = true;
        if (exitSceneBtn != null) exitSceneBtn.interactable = false;

        if (lidOpened)
        {
            // 水箱已经打开：显示开盖图，隐藏开盖按钮，没拿钥匙就显示钥匙
            toiletImgUI.texture = toiletOpenTex;
            toiletLidBtn.gameObject.SetActive(false);
            keyUI.SetActive(!keyGot);
        }
        else
        {
            // 水箱未打开：显示关盖图，显示开盖按钮，隐藏钥匙
            toiletImgUI.texture = toiletCloseTex;
            toiletLidBtn.gameObject.SetActive(true);
            keyUI.SetActive(false);
        }

        toiletImgUI.gameObject.SetActive(true);
        closeToiletBtn.gameObject.SetActive(true);
    }

    // 点击水箱盖子按钮，核心：必须有螺丝刀才能打开
    void ClickLid()
    {
        if (lidOpened) return;

        // 没有螺丝刀，提示，直接返回，无法开盖
        if (!HasScrewdriver)
        {
            ShowTip("找找其他工具吧");
            return;
        }

        // 拥有螺丝刀，打开水箱
        lidOpened = true;
        toiletImgUI.texture = toiletOpenTex;
        toiletLidBtn.gameObject.SetActive(false);
        keyUI.SetActive(true);
    }

    void ShowTip(string content)
    {
        if (tipText == null) return;
        tipText.text = content;
        tipText.gameObject.SetActive(true);
        tipTimer = tipShowTime;
    }

    // 拾取钥匙
    void PickKey()
    {
        keyGot = true;
        keyUI.SetActive(false);
        ShowTip("拿到钥匙了");
    }

    // 关闭马桶界面
    public void CloseToiletPanel()
    {
        panelActive = false;
        toiletImgUI.gameObject.SetActive(false);
        closeToiletBtn.gameObject.SetActive(false);
        toiletLidBtn.gameObject.SetActive(false);
        keyUI.SetActive(false);
        if (tipText != null) tipText.gameObject.SetActive(false);
        if (exitSceneBtn != null) exitSceneBtn.interactable = true;
    }
}