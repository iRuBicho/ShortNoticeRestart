using UnityEngine;
using UnityEngine.UI;

public class MenuButtonSFX : MonoBehaviour
{
    public enum ButtonType { Play, Options, Quit }
    public ButtonType buttonType;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        var audioManager = FindObjectOfType<MenuAudioManager>();
        switch (buttonType)
        {
            case ButtonType.Play:
                audioManager.PlaySFX(audioManager.playSFX);
                break;
            case ButtonType.Options:
                audioManager.PlaySFX(audioManager.optionsSFX);
                break;
            case ButtonType.Quit:
                audioManager.PlaySFX(audioManager.quitSFX);
                break;
        }
    }
}
