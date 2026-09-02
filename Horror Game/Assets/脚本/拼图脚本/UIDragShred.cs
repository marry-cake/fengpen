using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragShred : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rect;
    private Vector2 offset;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 计算鼠标和碎片中心点的偏移，解决鼠标错位
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
        FindObjectOfType<ShredPuzzleManager>().CheckFinish();
    }
}