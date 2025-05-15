using UnityEngine;
using PixelCrushers.QuestMachine;
using UnityEngine.Events;

public class PickupItem : MonoBehaviour
{
    public string questName;
    public string counterName;
    public KeyCode pickupKey = KeyCode.F;
    public UnityEvent onPickup; 
    private bool playerInside = false;
    private bool pickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            if (GetComponent<ShowInteractionPrompt>() != null && !pickedUp)
            {
                GetComponent<ShowInteractionPrompt>().enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            if (GetComponent<ShowInteractionPrompt>() != null)
            {
                GetComponent<ShowInteractionPrompt>().enabled = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (playerInside && !pickedUp && other.CompareTag("Player") && Input.GetKeyDown(pickupKey))
        {
            onPickup.Invoke(); 
            pickedUp = true;
            
            GetComponent<Collider>().enabled = false;
            if (GetComponent<ShowInteractionPrompt>() != null)
            {
                GetComponent<ShowInteractionPrompt>().enabled = false;
            }
            Destroy(gameObject, 0.1f);
        }
    }
}