using UnityEngine;

public class TVUIManager : MonoBehaviour
{
    [Header("三层UI面板拖拽赋值")]
    public GameObject panelTVClose;
    public GameObject panelTVOpen;
    public GameObject panelLock;

    // 【打开电视柜】按钮调用
    public void OpenTVBox()
    {
        panelTVClose.SetActive(false);
        panelTVOpen.SetActive(true);
    }

    // 【锁面板】按钮调用
    public void ShowLock()
    {
        panelTVOpen.SetActive(false);
        panelLock.SetActive(true);
    }

    // 玩家离开触发器关闭全部UI
    public void CloseAllTVUI()
    {
        panelTVClose.SetActive(false);
        panelTVOpen.SetActive(false);
        panelLock.SetActive(false);
    }
}