using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInteraction : MonoBehaviour
{
    public LumiaMovementStop lumiaMovementStop;
    public ItemManager itemManager;
    public string item1Tag = "Item1";
    public string item2Tag = "Item2";
    public Light streetLamp;
    public Transform interactionPoint;
    public FlickeringLight flickeringLightScript;  // Reference to the FlickeringLight script

    private bool isQuestCompleted = false;

    void Update()
    {
        if (Vector3.Distance(transform.position, interactionPoint.position) < 2f && lumiaMovementStop.hasStopped && !isQuestCompleted)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (HasRequiredItems())
                {
                    GiveItemsToLumia();
                    StopLightFlicker();
                    isQuestCompleted = true;
                    Debug.Log("Quest Completed!");
                }
                else
                {
                    Debug.Log("You don't have the required items!");
                }
            }
        }
    }

    private bool HasRequiredItems()
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

    private void GiveItemsToLumia()
    {
        foreach (GameObject item in itemManager.collectedItems)
        {
            if (item.CompareTag(item1Tag) || item.CompareTag(item2Tag))
            {
                item.SetActive(false);
                Debug.Log("Item given to Lumia: " + item.name);
            }
        }
    }

    private void StopLightFlicker()
    {
        if (flickeringLightScript != null)
        {
            flickeringLightScript.StopFlicker();  // Stop the flickering effect
            Debug.Log("Light flickering stopped.");
        }
    }
}
