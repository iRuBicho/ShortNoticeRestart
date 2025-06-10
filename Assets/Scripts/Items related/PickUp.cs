using UnityEngine;

public class PickupOnUse : MonoBehaviour
{
    public Sprite itemIcon;

    public void OnUse()
    {
        InventoryManager inventory = FindObjectOfType<InventoryManager>();
        if (inventory != null && itemIcon != null)
        {
            inventory.AddItem(itemIcon);
        }

        Destroy(gameObject);
    }
}
