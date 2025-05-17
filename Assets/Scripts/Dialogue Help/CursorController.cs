using UnityEngine;
using PixelCrushers.DialogueSystem;

public class CursorController : MonoBehaviour
{
    private CursorLockMode defaultLockMode = CursorLockMode.Locked;

    void Start()
    {
        SetCursorVisibility(false);
        SetCursorLockMode(defaultLockMode);
    }

    void Update()
    {
        if (DialogueManager.isConversationActive)
        {
            SetCursorVisibility(true);
            SetCursorLockMode(CursorLockMode.None);
        }
        else
        {
            SetCursorVisibility(false);
            SetCursorLockMode(defaultLockMode);
        }
    }

    void SetCursorVisibility(bool visible)
    {
        Cursor.visible = visible;
    }

    void SetCursorLockMode(CursorLockMode lockMode)
    {
        Cursor.lockState = lockMode;
    }
}