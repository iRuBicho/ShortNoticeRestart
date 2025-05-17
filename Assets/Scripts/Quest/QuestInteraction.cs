using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestInteraction : MonoBehaviour
{
    [Header("Item Requirements")]
    public ItemManager itemManager;
    public string item1Tag = "Item1";
    public string item2Tag = "Item2";

    [Header("Lamp Settings")]
    public Light streetLamp;
    public float minFlickerIntensity = 0.3f;
    public float maxFlickerIntensity = 1.5f;
    public float flickerSpeed = 0.05f;
    public float finalIntensity = 80f;

    public bool isQuestCompleted = false;
    private bool isFlickering = true;

    private void Start()
    {
        if (streetLamp == null)
        {
            streetLamp = GetComponent<Light>();
        }

        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (isFlickering)
        {
            if (streetLamp != null)
            {
                streetLamp.intensity = Random.Range(minFlickerIntensity, maxFlickerIntensity);
            }

            yield return new WaitForSeconds(flickerSpeed);
            yield return new WaitForSeconds(Random.Range(0.03f, 0.1f));
        }
    }

    public void SetLightIntensity(float intensity)
    {
        if (streetLamp != null)
        {
            streetLamp.intensity = intensity;
            Debug.Log("Street lamp intensity set to: " + intensity);
        }
        else
        {
            Debug.LogWarning("Street lamp is not assigned.");
        }
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
        StopFlickering();
        Debug.Log("Quest Completion Event Triggered.");
    }

    public bool HasRequiredItems()
    {
        bool hasItem1 = false;
        bool hasItem2 = false;

        foreach (GameObject item in itemManager.collectedItems)
        {
            if (item.CompareTag(item1Tag)) hasItem1 = true;
            if (item.CompareTag(item2Tag)) hasItem2 = true;
        }

        return hasItem1 && hasItem2;
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

        foreach (GameObject item in itemsToRemove)
        {
            itemManager.RemoveItem(item);
        }

        Debug.Log("All required items removed.");
    }

    public void StopFlickering()
    {
        isFlickering = false;
        StopAllCoroutines();

        if (streetLamp != null)
        {
            streetLamp.intensity = finalIntensity;
            Debug.Log("Flickering stopped. Lamp set to steady intensity: " + finalIntensity);
        }
    }
}
