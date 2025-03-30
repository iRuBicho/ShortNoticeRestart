using UnityEngine;
using TMPro;
using DialogueEditor;

public class LumiaConversationStarter : MonoBehaviour
{
    [SerializeField] public NPCConversation myConversation;
    [SerializeField] public TextMeshProUGUI pressFText;
    [SerializeField] public GameObject dialogueUI;

    public bool isNearPlayer = false;

    private void Update()
    {
        if (isNearPlayer)
        {
            pressFText.enabled = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(myConversation);
                pressFText.enabled = false;
                dialogueUI.SetActive(true);
            }
        }
        else
        {
            pressFText.enabled = false;
        }
    }

<<<<<<< HEAD
    public void OnSelectHaveItem()
    {
        Debug.Log("Player selected: I have the items.");
    }

=======
>>>>>>> parent of 940e821 (UI Dialogue)
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
