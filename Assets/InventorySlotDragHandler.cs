using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image iconImage;
    private Canvas canvas;
    private Transform originalParent;
    private Vector2 originalPosition;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = iconImage.transform.parent;
        originalPosition = iconImage.rectTransform.anchoredPosition;
        iconImage.transform.SetParent(canvas.transform);
        iconImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        iconImage.rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        iconImage.transform.SetParent(originalParent);
        iconImage.rectTransform.anchoredPosition = originalPosition;
        iconImage.raycastTarget = true;
    }
}
