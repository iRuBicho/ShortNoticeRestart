using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DialogueControlManager : MonoBehaviour
{
    private ProximitySelector selector;
    private CursorLockMode defaultLockMode = CursorLockMode.Locked;
    public MonoBehaviour playerController;

    void Start()
    {
        selector = GetComponent<ProximitySelector>();
        SetCursor(false, defaultLockMode);
    }

    void Update()
    {
        bool inDialogue = DialogueManager.isConversationActive;

        if (selector != null)
        {
            selector.useDefaultGUI = !inDialogue;
        }

        SetCursor(inDialogue, inDialogue ? CursorLockMode.None : defaultLockMode);

        if (playerController != null)
        {
            playerController.enabled = !inDialogue;
        }
    }

    void SetCursor(bool visible, CursorLockMode lockMode)
    {
        Cursor.visible = visible;
        Cursor.lockState = lockMode;
    }
}
