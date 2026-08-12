using UnityEngine;
using UnityEngine.UI;

public class PopTip : MonoBehaviour
{
    [Tooltip("提示文字UI，拖入你的Text")]
    public Text tipText;
    [Tooltip("文字显示时长(秒)")]
    public float showTime = 2f;
    [Tooltip("点击面板弹出的内容")]
    public string message = "抽屉已经打开，请查看里面线索";

    //点击面板触发
    public void OnPanelClick()
    {
        tipText.text = message;
        tipText.gameObject.SetActive(true);

        CancelInvoke(nameof(HideTip));
        Invoke(nameof(HideTip), showTime);
    }

    void HideTip()
    {
        tipText.gameObject.SetActive(false);
    }
}