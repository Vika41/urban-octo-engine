using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    private AudioMixerGroup _musicGroup;
    private AudioMixerGroup _sfxGroup;

    private const string MUSIC_GROUP_NAME = "Music";
    private const string SFX_GROUP_NAME = "SFX";
    private const string MASTER_VOLUME_NAME = "MasterVolume";
    private const string MUSIC_VOLUME_NAME = "MusicVolume";
    private const string SFX_VOLUME_NAME = "SFXVolume";

    private void Init()
    {
        _musicGroup = _mixer.FindMatchingGroups(MUSIC_GROUP_NAME)[0];
        _sfxGroup = _mixer.FindMatchingGroups(SFX_GROUP_NAME)[0];
    }

    public enum SoundType
    {
        Music,
        SFX
    }

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        Init();
    }

    public void ChangeMasterVolume(float newVol)
    {
        _mixer.SetFloat(MASTER_VOLUME_NAME, Mathf.Log10(newVol) * 20);
    }

    public void ChangeMusicVolume(float newVol)
    {
        _mixer.SetFloat(MUSIC_VOLUME_NAME, Mathf.Log10(newVol) * 20);
    }

    public void ChangeSFXVolume(float newVol)
    {
        _mixer.SetFloat(SFX_VOLUME_NAME, Mathf.Log10(newVol) * 20);
    }

    public void PlayAudio(AudioClip audioClip, SoundType soundType, float volume, bool loop)
    {
        GameObject newAudioSource = new(audioClip.name + " Source");
        AudioSource audioSource = newAudioSource.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = true;
        audioSource.loop = loop;
        audioSource.volume = volume;

        switch(soundType)
        {
            case SoundType.SFX:
                audioSource.outputAudioMixerGroup = Instance._sfxGroup;
                break;
            case SoundType.Music:
                audioSource.outputAudioMixerGroup = Instance._musicGroup;
                break;
            default:
                break;
        }

        audioSource.Play();

        if (!loop)
        {
            Destroy(audioSource.gameObject, audioClip.length);
        }
    }
}
