using UnityEngine;
using UnityEngine.UI;

public class PasswordDial : MonoBehaviour
{
    [Header("数字显示文本")]
    public Text numText;
    [Header("初始数字")]
    public int startNum = 0;
    private int currentNum;

    void Start()
    {
        currentNum = startNum;
        UpdateNumText();
    }

    // 数字+1
    public void AddNum()
    {
        currentNum++;
        if (currentNum > 9)
            currentNum = 0;
        UpdateNumText();
    }

    // 数字-1
    public void SubNum()
    {
        currentNum--;
        if (currentNum < 0)
            currentNum = 9;
        UpdateNumText();
    }

    // 更新文字显示
    void UpdateNumText()
    {
        numText.text = currentNum.ToString();
    }

    // 获取当前数字，给校验脚本使用
    public int GetCurrentNum()
    {
        return currentNum;
    }
}