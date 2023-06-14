using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : DucHienMonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] protected RectTransform rectTransform;
    private Vector2 startPosition;

    protected override void Awake()
    {
        base.Awake();
        rectTransform = GetComponent<RectTransform>();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        
        // Tính toán lượng di chuyển dựa trên tốc độ kéo và hệ số dragSpeed
        Vector2 displacement = eventData.delta * 0.025f;
        rectTransform.anchoredPosition += displacement;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition = startPosition;
    }

}
