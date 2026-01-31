using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static AudioManager;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _enemySounds = new List<AudioClip>();

    public static EnemyManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void OnArmlessAttack()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[0], SoundType.SFX, 0.5f, false);
    }

    public void OnArmlessDamage()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[1], SoundType.SFX, 0.5f, false);
    }

    public void OnArmlessDeath()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[2], SoundType.SFX, 0.5f, false);
    }
    
    public void OnBatAttack()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[3], SoundType.SFX, 0.5f, false);
    }

    public void OnBatDamage()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[4], SoundType.SFX, 0.5f, false);
    }

    public void OnBatDeath()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[5], SoundType.SFX, 0.5f, false);
    }

    public void OnRatAttack()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[6], SoundType.SFX, 0.5f, false);
    }

    public void OnRatDamage()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[7], SoundType.SFX, 0.5f, false);
    }

    public void OnRatDeath()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[8], SoundType.SFX, 0.5f, false);
    }
    
    public void OnSlimeAttack()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[9], SoundType.SFX, 0.5f, false);
    }

    public void OnSlimeDamage()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[10], SoundType.SFX, 0.5f, false);
    }

    public void OnSlimeDeath()
    {
        AudioManager.Instance.PlayAudio(_enemySounds[11], SoundType.SFX, 0.5f, false);
    }
}
