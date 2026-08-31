using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImagePageFlip : MonoBehaviour, IPointerClickHandler
{
    public Sprite[] spriteList;
    public Image displayImage;
    private int currentIndex;

    // 这个是关键：每次日记本打开(物体激活)自动重置第一页
    void OnEnable()
    {
        currentIndex = 0;
        if (spriteList.Length > 0)
            displayImage.sprite = spriteList[0];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentIndex >= spriteList.Length - 1) return;
        currentIndex++;
        displayImage.sprite = spriteList[currentIndex];
    }
}