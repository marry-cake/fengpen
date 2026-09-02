using UnityEngine;
using UnityEngine.UI;
public class TypeWriter1 : MonoBehaviour
{
    public float wordSpeed = 0.05f;
    private Text textUI;
    private string fullText = "";
    private string currentText = "";
    private float timer;
    public bool isFinish = true;

    void Awake()
    {
        textUI = GetComponent<Text>();
        Debug.Log($"【Awake】获取Text组件是否成功：{textUI != null}");
    }
   
    public void StartType(string str)
    {
        Debug.Log($"【StartType执行】传入字符串 = [{str}]");
        Debug.Log($"【StartType】传入字符串长度：{str?.Length}");

        if (textUI == null)
        {
            Debug.LogError("【致命】textUI是空！脚本没有挂在Legacy Text物体上！");
            return;
        }

        // 如果传入空字符串直接退出，不启动打字
        if (string.IsNullOrEmpty(str))
        {
            Debug.LogWarning("【StartType】传入文本为空，放弃打字");
            return;
        }

        // 如果正在打字，先结束上一轮，防止叠加文字
        if (!isFinish)
        {
            ShowAllText();
        }

        fullText = str;
        currentText = "";
        textUI.text = "";
        isFinish = false;
        timer = 0;

        Debug.Log($"【StartType结束】isFinish = {isFinish}，fullText=[{fullText}]");
    }

    void Update()
    {
        if (isFinish || textUI == null || string.IsNullOrEmpty(fullText))
        {
            if (!string.IsNullOrEmpty(fullText) && textUI != null)
            {
                Debug.Log($"【Update直接return】isFinish={isFinish}");
            }
            return;
        }

        timer += Time.deltaTime;
        if (timer >= wordSpeed)
        {
            timer = 0;
            if (currentText.Length < fullText.Length)
            {
                currentText = fullText.Substring(0, currentText.Length + 1);
                textUI.text = currentText;
                Debug.Log($"【输出字】currentText：{currentText}");
            }
            else
            {
                isFinish = true;
                Debug.Log($"【打字完成】isFinish设置为true");
            }
        }
    }

    /// <summary>跳过打字，直接展示全部文字（给按钮调用）</summary>
    public void ShowAllText()
    {
        Debug.Log("【ShowAllText被调用！】直接显示全部文字");
        if (textUI == null) return;
        textUI.text = fullText;
        isFinish = true;
    }

    // 新增：获取当前是否打字完毕，供DialogSwitch判断能不能切下一句
    public bool IsTypingFinished()
    {
        return isFinish;
    }
}