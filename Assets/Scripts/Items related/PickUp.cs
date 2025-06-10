using UnityEngine;

public class PickupOnUse : MonoBehaviour
{
    public string itemName = "FlashLight";
    public int amount = 1;
    public Sprite itemIcon;

    private bool pickedUp = false;

    public void OnUse()
    {
        if (pickedUp) return;
        pickedUp = true;

        InventoryManager inventory = FindObjectOfType<InventoryManager>();
        if (inventory != null && itemIcon != null)
        {
            inventory.AddItem(itemName, itemIcon);
        }

        Destroy(gameObject);
    }
}
