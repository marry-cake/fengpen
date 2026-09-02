using UnityEngine;
using UnityEngine.UI;

public class UIPuzzleShredPiece : MonoBehaviour
{
    [Header("碎片正确归位anchoredPosition")]
    public Vector2 targetPos;
    private RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public bool IsCorrect()
    {
        float distance = Vector2.Distance(rect.anchoredPosition, targetPos);
        return distance < 15f; //不规则碎片，容错放大到15像素
    }
}