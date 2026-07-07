using UnityEngine;

public class KeyPick : MonoBehaviour
{
    void OnMouseDown()
    {
        // 点击钥匙直接拾取消失
        gameObject.SetActive(false);
    }
}