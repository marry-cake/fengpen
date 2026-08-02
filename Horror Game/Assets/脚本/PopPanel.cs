using UnityEngine;
using UnityEngine.UI;

public class PopPanel : MonoBehaviour
{
    public Button closeButton;

    void Start()
    {
        if (closeButton != null)
            closeButton.onClick.AddListener(HidePanel);
    }

    // 外部按钮调用：显示弹窗
    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    // 关闭按钮调用：隐藏弹窗
    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
}