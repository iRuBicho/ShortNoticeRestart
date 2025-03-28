using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        // Optional: Set initial value based on AudioManager's current volume
        musicSlider.value = audioManager.GetComponent<AudioSource>().volume;

        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
    }

    private void ChangeMusicVolume(float volume)
    {
        audioManager.SetMusicVolume(volume);
    }
}
