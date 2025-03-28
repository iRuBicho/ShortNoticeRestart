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

        // Deactivate all items
        foreach (GameObject obj in collectedItems)
        {
            obj.SetActive(false);
        }

        // Set current index to last picked
        currentIndex = collectedItems.Count - 1;
        collectedItems[currentIndex].SetActive(true);
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
}
