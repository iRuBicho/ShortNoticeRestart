using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource sfx;

    public AudioClip playSFX;
    public AudioClip optionsSFX;
    public AudioClip quitSFX;

    void Start()
    {
        backgroundMusic.loop = true;
        backgroundMusic.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}
