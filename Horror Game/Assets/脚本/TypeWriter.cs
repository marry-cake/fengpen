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

    public void StartType(string str)
    {
        if (textUI == null) return;
        fullText = str;
        currentText = "";
        textUI.text = "";
        isFinish = false;
        timer = 0;
    }

    void Update()
    {
        // 双重判定，为空直接跳出，不会执行后面代码报错
        if (isFinish || textUI == null || string.IsNullOrEmpty(fullText))
            return;

        timer += Time.deltaTime;
        if (timer >= wordSpeed)
        {
            timer = 0;
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

    public void ShowAllText()
    {
        if (textUI == null) return;
        textUI.text = fullText;
        isFinish = true;
    }
}