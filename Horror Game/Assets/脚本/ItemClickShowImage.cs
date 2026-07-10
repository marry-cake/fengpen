using UnityEngine;

public class ItemClickShowImage : MonoBehaviour
{
    [Tooltip("点击后弹出的UI面板")]
    public GameObject popupPanel;

    // 鼠标点击触发
    private void OnMouseDown()
    {
        if (popupPanel != null)
        {
            // 切换显示/隐藏，点一次显示，再点一次关闭
            popupPanel.SetActive(!popupPanel.activeSelf);
        }
    }
}