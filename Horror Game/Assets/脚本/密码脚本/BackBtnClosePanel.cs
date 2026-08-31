using UnityEngine;

public class BackBtnClosePanel : MonoBehaviour
{
    [Tooltip("要关闭的目标面板物体")]
    public GameObject targetPanel;

    // 按钮绑定调用这个方法
    public void ClosePanel()
    {
        if (targetPanel != null)
        {
            targetPanel.SetActive(false);
        }
    }
}