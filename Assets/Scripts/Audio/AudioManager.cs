using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource ambientSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip background;
    public AudioClip ambient;
    public AudioClip walking;
    public AudioClip jump;

    [Header("-------- Volume Settings --------")]
    [Range(0f, 1f)] public float musicVolume = 1f;
    [Range(0f, 1f)] public float ambientVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    private void Start()
    {
        
        musicSource.clip = background;
        musicSource.volume = musicVolume;
        musicSource.loop = true;
        musicSource.Play();

        
        ambientSource.clip = ambient;
        ambientSource.volume = ambientVolume;
        ambientSource.loop = true;
        ambientSource.Play();

        
        SFXSource.volume = sfxVolume;
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        musicSource.volume = musicVolume;
    }

    public void SetAmbientVolume(float volume)
    {
        ambientVolume = volume;
        ambientSource.volume = ambientVolume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        SFXSource.volume = sfxVolume;
    }
}
