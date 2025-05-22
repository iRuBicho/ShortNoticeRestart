using UnityEngine;
using PixelCrushers;

public class PickupOnUse : MonoBehaviour
{
    public string itemName = "Lamp";
    public int amount = 1;
    private bool pickedUp = false;

    public void OnUse()
    {
        if (pickedUp) return;
        pickedUp = true;

        MessageSystem.SendMessage(this, "item", itemName, amount);
        GameInventory.AddItem(itemName);



        Destroy(gameObject);
    }
}
