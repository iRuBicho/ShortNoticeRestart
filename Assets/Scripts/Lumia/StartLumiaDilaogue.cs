using UnityEngine;
using PixelCrushers.DialogueSystem;

public class StartLumiaDialogue : MonoBehaviour
{
    public string conversationTitle = "Lumia IC";

    public void StartConversation()
    {
        DialogueManager.StartConversation(conversationTitle);
    }
}