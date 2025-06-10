using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotDropHandler : MonoBehaviour, IDropHandler
{
    public Image iconImage; 

    public void OnDrop(PointerEventData eventData)
    {
        InventorySlotDragHandler dragHandler = eventData.pointerDrag?.GetComponent<InventorySlotDragHandler>();
        if (dragHandler == null || dragHandler.iconImage.sprite == null) return;

        Image draggedIcon = dragHandler.iconImage;
        Image targetIcon = iconImage;

        
        Sprite tempSprite = targetIcon.sprite;
        Color tempColor = targetIcon.color;
        string tempName = targetIcon.name;

        targetIcon.sprite = draggedIcon.sprite;
        targetIcon.color = new Color(1, 1, 1, 1);
        targetIcon.name = draggedIcon.name;

        draggedIcon.sprite = tempSprite;
        draggedIcon.color = tempSprite == null ? new Color(1, 1, 1, 0) : new Color(1, 1, 1, 1);
        draggedIcon.name = tempName;
    }
}
