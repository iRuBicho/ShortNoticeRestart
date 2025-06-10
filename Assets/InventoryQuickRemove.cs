using UnityEngine;

public class InventoryQuickRemove : MonoBehaviour
{
    public string[] itemsToRemove;

    public void RemoveItems()
    {
        var manager = FindObjectOfType<InventoryManager>();
        foreach (string itemName in itemsToRemove)
        {
            manager.RemoveItemByName(itemName);
        }
    }
}
