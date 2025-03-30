using UnityEngine;
using DialogueEditor;

public class DialogueController : MonoBehaviour
{
    public FPSController cameraController;
    public QuestInteraction questInteraction;
    public LumiaConversationStarter lumiaConversationStarter;

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
            }
        }

        if (!ConversationManager.Instance.IsConversationActive)
        {
            if (Input.GetKeyDown(KeyCode.G) && questInteraction != null && !questInteraction.isQuestCompleted)
            {
                if (questInteraction.HasRequiredItems())
                {
                    questInteraction.RemoveItemsFromInventory();
                    questInteraction.StopLightFlicker();
                    questInteraction.isQuestCompleted = true;
                    Debug.Log("Items given to Lumia! The quest is complete.");
                }
            }

            if (Input.GetKeyDown(KeyCode.F) && lumiaConversationStarter != null && lumiaConversationStarter.isNearPlayer)
            {
                lumiaConversationStarter.dialogueUI.SetActive(true);
                ConversationManager.Instance.StartConversation(lumiaConversationStarter.myConversation);
            }
        }
    }
}
