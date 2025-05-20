using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DialogueCameraStopper : MonoBehaviour
{
    public FPSController playerFPSController;

    void Update()
    {
        if (playerFPSController != null)
        {
            playerFPSController.canLook = !DialogueManager.isConversationActive;
        }
    }
}