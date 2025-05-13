using UnityEngine;
using PixelCrushers.DialogueSystem;

public class StartLumiaDialogue : MonoBehaviour
{
    public string conversationTitle = "Lumia Lamp Explanation";

    public void StartConversation()
    {
        DialogueManager.StartConversation(conversationTitle);
    }
}