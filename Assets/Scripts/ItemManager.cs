using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> collectedItems = new List<GameObject>();
    private int currentIndex = -1;

    void Update()
    {
        if (collectedItems.Count == 0) return;

        if (Input.GetKeyDown(KeyCode.E))
            SwitchNextItem();

        if (Input.GetKeyDown(KeyCode.Q))
            SwitchPreviousItem();
    }

    public void AddItem(GameObject item)
    {
        if (item == null) return;

        collectedItems.Add(item);
        item.SetActive(true);
        currentIndex = collectedItems.Count - 1;
    }

    private void SwitchNextItem()
    {
        if (collectedItems.Count == 0) return;

        collectedItems[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % collectedItems.Count;
        collectedItems[currentIndex].SetActive(true);
    }

    private void SwitchPreviousItem()
    {
        if (collectedItems.Count == 0) return;

        collectedItems[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + collectedItems.Count) % collectedItems.Count;
        collectedItems[currentIndex].SetActive(true);
    }

    public void RemoveItem(GameObject item)
    {
        if (collectedItems.Contains(item))
        {
            collectedItems.Remove(item);
            Destroy(item); 
            Debug.Log("Removed item: " + item.name);
        }
        else
        {
            Debug.Log("Item not found in inventory: " + item.name);
        }
    }
    public void UpdateCurrentItemAfterRemoval()
    {
        if (collectedItems.Count == 0)
        {
            currentIndex = -1;
            return;
        }

        if (currentIndex >= collectedItems.Count)
        {
            currentIndex = collectedItems.Count - 1;
        }

        foreach (GameObject obj in collectedItems)
        {
            obj.SetActive(false);
        }

        collectedItems[currentIndex].SetActive(true);
    }


    public GameObject GetCurrentItem()
    {
        if (collectedItems.Count == 0) return null;
        return collectedItems[currentIndex];
    }
}
