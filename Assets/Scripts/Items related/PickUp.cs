using UnityEngine;
using PixelCrushers;

public class PickupOnUse : MonoBehaviour
{
    public string itemName = "Lamp";
    public int amount = 1;
    public Sprite itemIcon;
    private bool pickedUp = false;

    public void OnUse()
    {
        if (pickedUp) return;
        pickedUp = true;

        MessageSystem.SendMessage(this, "item", itemName, amount);
        GameInventory.AddItem(itemName);

        InventorySystem uiInventory = FindObjectOfType<InventorySystem>();
        if (uiInventory != null && itemIcon != null)
        {
            uiInventory.AddItem(itemName, itemIcon);
        }

        Destroy(gameObject);
    }
}
