using UnityEngine;
using UnityEngine.UI;

public class MarriageCertPopup : MonoBehaviour
{
    [Header("结婚证弹窗")]
    public GameObject certPopup;

    [Header("返回按钮")]
    public Button backBtn;

    void Start()
    {
        certPopup.SetActive(false);

        if (backBtn != null)
        {
            backBtn.onClick.AddListener(ClosePopup);
        }
    }

    // 结婚照按钮点击
    public void OpenPopup()
    {
        certPopup.SetActive(true);
    }

    // 返回按钮点击
    public void ClosePopup()
    {
        certPopup.SetActive(false);
    }
}