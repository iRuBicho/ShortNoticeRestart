using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ShowInteractionPrompt : MonoBehaviour
{
    public string promptText = "Press F to Talk";
    public KeyCode interactionKey = KeyCode.F;
    public string conversationTitle = "Lumia Lamp Explanation"; 

    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            DialogueManager.ShowAlert(promptText + " (" + interactionKey.ToString() + ")");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            DialogueManager.HideAlert();
        }
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(interactionKey))
        {
            DialogueManager.StartConversation(conversationTitle);
        }
    }
}