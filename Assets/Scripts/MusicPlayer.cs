using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip _backgroundMusic;

    void Start()
    {
        AudioManager.Instance.PlayAudio(_backgroundMusic, SoundType.Music, 1.0f, true);
    }
}
