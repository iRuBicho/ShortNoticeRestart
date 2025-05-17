using UnityEngine;
using UnityEngine.EventSystems;
using PixelCrushers.DialogueSystem;

public class DialogueStateController : MonoBehaviour
{
    public FPSController cameraController;
    public QuestInteraction questInteraction;

    public Collider lumiaCollider;
    public Canvas dialogueCanvas;

    void Update()
    {
        if (DialogueManager.instance != null && DialogueManager.instance.isInitialized)
        {
            if (cameraController != null)
            {
                cameraController.enabled = false;
            }

            if (lumiaCollider != null)
            {
                lumiaCollider.enabled = false;
            }

            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            if (cameraController != null)
            {
                cameraController.enabled = true;
            }

            if (lumiaCollider != null)
            {
                lumiaCollider.enabled = true;
            }
        }
    }

    public void CheckItemsForQuest()
    {
        if (questInteraction.HasRequiredItems())
        {
            questInteraction.RemoveItemsFromInventory();
            questInteraction.isQuestCompleted = true;
            questInteraction.SetLightIntensity(40f);
            Debug.Log("Items given to Lumia! The quest is complete.");
            Debug.Log("Quest Completion Successful!");
        }
        else
        {
            Debug.Log("Player does not have the required items.");
        }
    }
}