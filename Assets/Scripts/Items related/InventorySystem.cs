using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public List<Image> itemSlots = new List<Image>();
    public Sprite emptySlotSprite;

    void Start()
    {
        if (itemSlots.Count == 0)
        {
            Transform slotParent = transform.Find("Inventory Slots");
            if (slotParent != null)
            {
                foreach (Transform child in slotParent)
                {
                    Image img = child.GetComponent<Image>();
                    if (img != null)
                    {
                        itemSlots.Add(img);
                    }
                }
            }
        }
    }

    public void AddItem(string itemName, Sprite itemIcon)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].name == itemName)
                return;

            if (itemSlots[i].sprite == emptySlotSprite)
            {
                itemSlots[i].sprite = itemIcon;
                itemSlots[i].name = itemName;
                return;
            }
        }
    }

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].name == itemName)
            {
                itemSlots[i].sprite = emptySlotSprite;
                itemSlots[i].name = "Empty";
                return;
            }
        }
    }
}
