using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject pickUpText;
    public GameObject BlockOnPlayer;
    public Sprite itemSprite;

    private Inventory inventory;
    private ItemManager itemManager;

    void Start()
    {
        pickUpText.SetActive(false);
        inventory = GameObject.Find("HUD").GetComponent<Inventory>();
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Picked up item: " + itemSprite.name);

                gameObject.SetActive(false);
                pickUpText.SetActive(false);
                inventory.AddItemToInventory(itemSprite);

                // Add item to ItemManager
                itemManager.AddItem(BlockOnPlayer);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(false);
        }
    }
}
