using System.Collections.Generic;
using UnityEngine;

public class QuestInteraction : MonoBehaviour
{
    public ItemManager itemManager;
    public string item1Tag = "Item1";
    public string item2Tag = "Item2";
    public Light streetLamp;  
    public Transform interactionPoint;

    public bool isQuestCompleted = false;

    public bool HasRequiredItems()
    {
        bool hasItem1 = false;
        bool hasItem2 = false;

        foreach (GameObject item in itemManager.collectedItems)
        {
            if (item.CompareTag(item1Tag))
                hasItem1 = true;

            if (item.CompareTag(item2Tag))
                hasItem2 = true;
        }

        return hasItem1 && hasItem2;
    }

    public void CompleteQuest()
    {
        if (!HasRequiredItems())
        {
            Debug.Log("Player does not have the required items.");
            return;
        }

        Debug.Log("Quest completed. Items given to Lumia.");
        isQuestCompleted = true;

        RemoveItemsFromInventory();
        SetLightIntensity(80f);  // Set light intensity to 80 after quest completion
        Debug.Log("Quest Completion Event Triggered.");
    }

    public void RemoveItemsFromInventory()
    {
        List<GameObject> itemsToRemove = new List<GameObject>();

        foreach (GameObject item in itemManager.collectedItems)
        {
            if (item.CompareTag(item1Tag) || item.CompareTag(item2Tag))
            {
                itemsToRemove.Add(item);
            }
        }

        if (itemsToRemove.Count > 0)
        {
            foreach (GameObject item in itemsToRemove)
            {
                itemManager.RemoveItem(item);
            }

            Debug.Log("All required items removed.");
         
        }
    }

    public void SetLightIntensity(float intensity)
    {
        if (streetLamp != null)
        {
            streetLamp.intensity = intensity;  // Set the light intensity immediately,should be to 80!!!!
            Debug.Log("Street lamp intensity set to " + intensity);
        }
        else
        {
            Debug.LogWarning("Street lamp is not assigned in the inspector.");
        }
    }
}
