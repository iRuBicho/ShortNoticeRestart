using UnityEngine;
using UnityEngine.EventSystems;
using DialogueEditor;

public class DialogueController : MonoBehaviour
{
    public FPSController cameraController;
    public QuestInteraction questInteraction;
    public LumiaConversationStarter lumiaConversationStarter;
    public Collider lumiaCollider;
    public Canvas dialogueCanvas;

    void Update()
    {
        if (ConversationManager.Instance != null)
        {
            if (ConversationManager.Instance.IsConversationActive)
            {
                if (cameraController != null)
                {
                    cameraController.enabled = false;
                }

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                if (lumiaCollider != null)
                {
                    lumiaCollider.enabled = false;
                }

                if (dialogueCanvas != null)
                {
                    CanvasGroup canvasGroup = dialogueCanvas.GetComponent<CanvasGroup>();
                    if (canvasGroup != null)
                    {
                        canvasGroup.interactable = false;
                    }
                }

                // **Manually reset selection**
                EventSystem.current.SetSelectedGameObject(null);

                if (Input.GetMouseButtonDown(0))
                {
                    ConversationManager.Instance.PressSelectedOption();
                }
            }
            else
            {
                if (cameraController != null)
                {
                    cameraController.enabled = true;
                }

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                if (lumiaCollider != null)
                {
                    lumiaCollider.enabled = true;
                }

                if (dialogueCanvas != null)
                {
                    CanvasGroup canvasGroup = dialogueCanvas.GetComponent<CanvasGroup>();
                    if (canvasGroup != null)
                    {
                        canvasGroup.interactable = true;
                    }
                }
            }
        }

        if (!ConversationManager.Instance.IsConversationActive)
        {
            if (lumiaConversationStarter != null && lumiaConversationStarter.isNearPlayer)
            {
                lumiaConversationStarter.dialogueUI.SetActive(true);
                ConversationManager.Instance.StartConversation(lumiaConversationStarter.myConversation);
            }
        }
    }

    public void CheckItemsForQuest()
    {
        if (questInteraction.HasRequiredItems())
        {
            questInteraction.RemoveItemsFromInventory();
            questInteraction.StopLightFlicker();
            questInteraction.isQuestCompleted = true;
            Debug.Log("Items given to Lumia! The quest is complete.");
        }
        else
        {
            Debug.Log("Player does not have the required items.");
            if (lumiaConversationStarter != null)
            {
                ConversationManager.Instance.StartConversation(lumiaConversationStarter.myConversation);
            }
        }
    }
}
