using UnityEngine;
using TMPro;
using DialogueEditor;

public class LumiaConversationStarter : MonoBehaviour
{
    [SerializeField] public NPCConversation myConversation;
    [SerializeField] public TextMeshProUGUI pressFText;
    [SerializeField] public GameObject dialogueUI;

    public bool isNearPlayer = false;

    private void Start()
    {
        pressFText.enabled = false; // Ensure it is hidden initially
    }

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
}
