using UnityEngine;
using TMPro;
using DialogueEditor;

public class LumiaConversationStarter : MonoBehaviour
{
    [SerializeField] public NPCConversation myConversation;  // Make public so it's accessible
    [SerializeField] public TextMeshProUGUI pressFText;
    [SerializeField] public GameObject dialogueUI;  // Make public so it's accessible

    public bool isNearPlayer = false;
    private float dialogueTimer = 0f;
    private float maxDialogueTime = 15f;

    private void Update()
    {
        if (isNearPlayer)
        {
            pressFText.enabled = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(myConversation);
                pressFText.enabled = false;
                dialogueTimer = maxDialogueTime;
                dialogueUI.SetActive(true);
            }

            if (dialogueUI.activeSelf)
            {
                dialogueTimer -= Time.deltaTime;
            }

            if (dialogueTimer <= 0f)
            {
                EndDialogue();
            }

            if (Input.GetKeyDown(KeyCode.Space) && dialogueUI.activeSelf)
            {
                EndDialogue();
            }
        }
        else
        {
            pressFText.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearPlayer = false;
        }
    }

    private void EndDialogue()
    {
        ConversationManager.Instance.EndConversation();
        dialogueUI.SetActive(false);
    }
}
