using UnityEngine;
using UnityEngine.UI;

public class NumSlot : MonoBehaviour
{
    [Header("数字显示图片（自身Image）")]
    public Image numImage;
    [Header("0-9 数字精灵数组，依次拖入分割好的0、1、2...9")]
    public Sprite[] digitSprites;

    // 当前选中数字 0~9
    public int CurrentNum { get; private set; } = 0;

    void Start()
    {
        // 初始化显示数字0
        RefreshSprite();
        // 绑定自身Button点击事件
        GetComponent<Button>().onClick.AddListener(SwitchNext);
    }

    // 点击切换下一个数字，9循环回0
    public void SwitchNext()
    {
        CurrentNum++;
        if (CurrentNum >= 10) CurrentNum = 0;
        RefreshSprite();
    }

    // 更新图片显示当前数字
    void RefreshSprite()
    {
        numImage.sprite = digitSprites[CurrentNum];
    }
}