using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LockManager : MonoBehaviour
{
    [Header("四个数字位，依次拖入num1、num2、num3、num4")]
    public NumSlot[] slots;
    [Header("设置你的4位正确密码")]
    public int[] correctPassword = { 4, 3, 1, 9 };
    [Header("提示文字（拖你新建的TipText）")]
    public Text tipText;
    [Header("确定按钮（拖层级里的「确定」物体）")]
    public Button confirmBtn;

    [Header("面板切换设置")]
    [Tooltip("当前密码锁面板")]
    public GameObject lockPanel;
    [Tooltip("密码正确后跳转显示的面板")]
    public GameObject successPanel;

    void Start()
    {
        tipText.gameObject.SetActive(false);
        // 重要：两种绑定方式只能选一个
        // 如果你要在按钮界面手动选择CheckPassword方法，请把下面这行注释掉
        // confirmBtn.onClick.AddListener(CheckPassword);
    }

    // public公开修饰，可以在按钮OnClick下拉列表中被找到
    public void CheckPassword()
    {
        bool pass = true;
        for (int i = 0; i < 4; i++)
        {
            if (slots[i].CurrentNum != correctPassword[i])
            {
                pass = false;
                break;
            }
        }

        tipText.gameObject.SetActive(true);
        if (pass)
        {
            tipText.text = "密码正确";
            tipText.color = Color.green;
            // 2秒后切换面板
            StartCoroutine(SwitchPanelAfterDelay());
        }
        else
        {
            tipText.text = "密码错误，请重新输入";
            tipText.color = Color.red;
            StartCoroutine(AutoHideTip());
        }
    }

    // 2秒后隐藏提示，关闭密码面板，打开成功面板
    IEnumerator SwitchPanelAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        tipText.gameObject.SetActive(false);
        lockPanel.SetActive(false);  // 关闭密码锁界面
        successPanel.SetActive(true); // 打开新面板
    }

    // 密码错误，2秒隐藏提示
    IEnumerator AutoHideTip()
    {
        yield return new WaitForSeconds(2f);
        tipText.gameObject.SetActive(false);
    }
}