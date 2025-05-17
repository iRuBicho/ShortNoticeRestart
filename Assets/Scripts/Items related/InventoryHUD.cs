using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventorySlots;
    private int currentSlotIndex = 0;

    void Start()
    {
        foreach (GameObject slot in inventorySlots)
        {
            slot.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void AddItemToInventory(Sprite itemSprite)
    {
        if (currentSlotIndex < inventorySlots.Length)
        {
            GameObject currentItem = inventorySlots[currentSlotIndex].transform.GetChild(0).gameObject;
            Image slotImage = currentItem.GetComponent<Image>();
            slotImage.sprite = itemSprite;
            currentItem.SetActive(true);
            currentSlotIndex++;
        }
        else
        {
            GameObject firstSlotItem = inventorySlots[0].transform.GetChild(0).gameObject;
            Image firstSlotImage = firstSlotItem.GetComponent<Image>();
            firstSlotImage.sprite = itemSprite;
            firstSlotItem.SetActive(true);
        }
    }

    public void ResetInventory()
    {
        currentSlotIndex = 0;
        foreach (GameObject slot in inventorySlots)
        {
            slot.transform.GetChild(0).gameObject.SetActive(false);
            slot.transform.GetChild(0).GetComponent<Image>().sprite = null;
        }
    }
}
