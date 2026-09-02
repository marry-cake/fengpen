using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
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
    }

    /// <summary>开启逐字打字</summary>
    public void StartType(string str)
    {
        if (textUI == null) return;

        fullText = str;
        currentText = "";
        textUI.text = "";
        isFinish = false;
        timer = 0f;
    }

    void Update()
    {
        if (isFinish || textUI == null || string.IsNullOrEmpty(fullText))
            return;

        timer += Time.deltaTime;
        if (timer >= wordSpeed)
        {
            timer = 0;
            // 还有字符没输出
            if (currentText.Length < fullText.Length)
            {
                currentText = fullText.Substring(0, currentText.Length + 1);
                textUI.text = currentText;
            }
            else
            {
                isFinish = true;
            }
        }
    }

    /// <summary>一键显示全部文字（点击跳过）</summary>
    public void ShowAllText()
    {
        if (textUI == null) return;
        textUI.text = fullText;
        currentText = fullText;
        isFinish = true;
    }

    /// <summary>清空文本</summary>
    public void ClearText()
    {
        fullText = "";
        currentText = "";
        textUI.text = "";
        isFinish = true;
    }
}
