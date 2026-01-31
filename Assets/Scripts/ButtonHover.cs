using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    [SerializeField] private AudioClip _hoverSFX;

    private void OnMouseOver()
    {
        AudioManager.Instance.PlayAudio(_hoverSFX, AudioManager.SoundType.SFX, 0.8f, false);
    }
}
