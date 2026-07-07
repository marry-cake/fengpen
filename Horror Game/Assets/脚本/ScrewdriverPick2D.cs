using UnityEngine;

public class ScrewdriverPick2D : MonoBehaviour
{
    private bool isPicked = false;

    void OnMouseDown()
    {
        if (isPicked) return;
        isPicked = true;

        // 全局标记获得螺丝刀，马桶脚本会读取这个值
        ToiletInteract.HasScrewdriver = true;

        // 拾取后直接隐藏螺丝刀
        gameObject.SetActive(false);
    }
}