using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public List<Image> itemIcons = new List<Image>();

    void Start()
    {
        if (itemIcons.Count == 0)
        {
            foreach (Transform slot in transform)
            {
                Transform icon = slot.Find("Icon");
                if (icon != null)
                {
                    Image img = icon.GetComponent<Image>();
                    if (img != null)
                    {
                        itemIcons.Add(img);
                        img.color = new Color(1, 1, 1, 0); // make transparent
                    }
                }
            }
        }
    }

    public void AddItem(string itemName, Sprite itemIcon)
    {
        for (int i = 0; i < itemIcons.Count; i++)
        {
            if (itemIcons[i].sprite == null)
            {
                itemIcons[i].sprite = itemIcon;
                itemIcons[i].color = new Color(1, 1, 1, 1); // make visible
                itemIcons[i].gameObject.name = itemName;
                return;
            }
        }
    }

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < itemIcons.Count; i++)
        {
            if (itemIcons[i].gameObject.name == itemName)
            {
                itemIcons[i].sprite = null;
                itemIcons[i].color = new Color(1, 1, 1, 0); // make invisible
                itemIcons[i].gameObject.name = "Icon";
                return;
            }
        }
    }
}
