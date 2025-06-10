using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour // Youtube:https://www.youtube.com/watch?v=0wKB_rxtqh4&list=PLSR2vNOypvs6eIxvTu-rYjw2Eyw57nZrU
{
    public GameObject inventoryMenu;
    public Transform slotParent;
    public MonoBehaviour playerMovement;
    public MonoBehaviour cameraLook;

    private List<ItemSlot> itemSlots = new List<ItemSlot>();
    private bool menuOpen = false;

    void Start()
    {
        foreach (Transform child in slotParent)
        {
            ItemSlot slot = child.GetComponent<ItemSlot>();
            if (slot != null)
            {
                itemSlots.Add(slot);
            }
        }

        inventoryMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            menuOpen = !menuOpen;
            inventoryMenu.SetActive(menuOpen);

            Cursor.visible = menuOpen;
            Cursor.lockState = menuOpen ? CursorLockMode.None : CursorLockMode.Locked;

            if (playerMovement != null) playerMovement.enabled = !menuOpen;
            if (cameraLook != null) cameraLook.enabled = !menuOpen;
        }
    }

    public void AddItem(Sprite icon)
    {
        foreach (ItemSlot slot in itemSlots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(icon);
                return;
            }
        }
    }
}
