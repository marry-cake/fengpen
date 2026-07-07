using UnityEngine;
using UnityEngine.UI;

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

    [Header("马桶盖子点击按钮（盖在马桶图上）")]
    public Button toiletLidBtn;
    [Header("关闭马桶界面按钮")]
    public Button closeToiletBtn;
    [Header("全局退出场景按钮")]
    public Button exitSceneBtn;

    [Header("提示文字框")]
    public Text tipText;
    public float tipShowTime = 1.5f;

    [Header("马桶内钥匙UI（普通Image/RawImage，不加Button）")]
    public GameObject keyUI;

    public static bool HasScrewdriver = false;

    private bool panelActive = false;
    private bool lidOpened = false;
    private float tipTimer;

    void Start()
    {
        toiletImgUI.gameObject.SetActive(false);
        closeToiletBtn.gameObject.SetActive(false);
        toiletLidBtn.gameObject.SetActive(false);
        keyUI.SetActive(false);
        if (tipText != null) tipText.gameObject.SetActive(false);

        if (exitSceneBtn != null)
            exitSceneBtn.interactable = true;

        if (closeToiletBtn != null)
            closeToiletBtn.onClick.AddListener(CloseToiletPanel);
        if (toiletLidBtn != null)
            toiletLidBtn.onClick.AddListener(ClickLid);
    }

    // 唯一合并后的Update，包含提示倒计时+钥匙点击检测
    void Update()
    {
        // 提示文字自动消失逻辑
        if (tipText != null && tipText.gameObject.activeSelf)
        {
            tipTimer -= Time.deltaTime;
            if (tipTimer <= 0)
                tipText.gameObject.SetActive(false);
        }

        // 钥匙鼠标点击拾取逻辑
        if (panelActive && keyUI.activeSelf && Input.GetMouseButtonDown(0))
        {
            RectTransform keyRect = keyUI.GetComponent<RectTransform>();
            Vector2 mousePos = Input.mousePosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                keyRect, mousePos, null, out Vector2 localPoint))
            {
                Vector2 size = keyRect.sizeDelta / 2f;
                if (Mathf.Abs(localPoint.x) < size.x && Mathf.Abs(localPoint.y) < size.y)
                {
                    PickKey();
                }
            }
        }
    }

    public void OpenToilet()
    {
        if (panelActive) return;
        panelActive = true;

        if (exitSceneBtn != null)
            exitSceneBtn.interactable = false;

        toiletImgUI.texture = toiletCloseTex;
        toiletImgUI.gameObject.SetActive(true);
        closeToiletBtn.gameObject.SetActive(true);
        toiletLidBtn.gameObject.SetActive(true);
    }

    void ClickLid()
    {
        if (lidOpened) return;

        if (!HasScrewdriver)
        {
            ShowTip("找找其他工具吧");
            return;
        }

        lidOpened = true;
        toiletImgUI.texture = toiletOpenTex;
        keyUI.SetActive(true);
    }

    void ShowTip(string content)
    {
        if (tipText == null) return;
        tipText.text = content;
        tipText.gameObject.SetActive(true);
        tipTimer = tipShowTime;
    }

    public void CloseToiletPanel()
    {
        panelActive = false;
        toiletImgUI.gameObject.SetActive(false);
        closeToiletBtn.gameObject.SetActive(false);
        toiletLidBtn.gameObject.SetActive(false);
        keyUI.SetActive(false);
        if (tipText != null) tipText.gameObject.SetActive(false);

        if (exitSceneBtn != null)
            exitSceneBtn.interactable = true;
    }

    void PickKey()
    {
        keyUI.SetActive(false);
        ShowTip("拿到钥匙了");
    }
}