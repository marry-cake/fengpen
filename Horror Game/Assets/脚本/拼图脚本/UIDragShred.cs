using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragShred : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("吸附设置：像素距离")]
    public float snapDistance = 60f; // 离目标多少像素就自动吸过去，数值越大越容易吸附
    private RectTransform rect;
    private Vector2 offset;
    private UIPuzzleShredPiece shredPiece;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        shredPiece = GetComponent<UIPuzzleShredPiece>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localMousePos);

        offset = rect.anchoredPosition - localMousePos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localMousePos);

        rect.anchoredPosition = localMousePos + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 拖拽松手，执行吸附逻辑
        TrySnapToTarget();
        FindObjectOfType<ShredPuzzleManager>().CheckFinish();
    }

    void TrySnapToTarget()
    {
        if (shredPiece == null) return;

        Vector2 targetPos = shredPiece.targetPos;
        float distance = Vector2.Distance(rect.anchoredPosition, targetPos);

        // 距离小于阈值，直接吸附到正确位置
        if (distance <= snapDistance)
        {
            rect.anchoredPosition = targetPos;
        }
    }
}