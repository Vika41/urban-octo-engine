using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] private int _currentLevel = 0;
    [SerializeField] private int _currentXP = 0;
    [SerializeField] private int _levelMaxXP = 5;
    [SerializeField] private float _xpGrowth = 1.25f;

    [SerializeField] private AudioClip _levelUp;

    public Action<int> OnLevelUp;
    public Action<int, int> OnXPGained;

    public static LevelUpManager Instance { get; private set; }

    private void Awake()
    {
        //if (Instance != null)
        //{
            //Destroy(this);
        //}
        Instance = this;
    }

    public void GetXP(int xp)
    {
        _currentXP += xp;
        if (_currentXP >= _levelMaxXP)
        {
            int xpOverflow = _currentXP - _levelMaxXP;
            LevelUp(xpOverflow);
        }

        OnXPGained?.Invoke(_currentXP, _levelMaxXP);
    }

    private void LevelUp(int xpOverflow)
    {
        AudioManager.Instance.PlayAudio(_levelUp, SoundType.SFX, 0.5f, false);

        _currentLevel++;
        _currentXP = xpOverflow;
        _levelMaxXP = (int)(_levelMaxXP * _xpGrowth);

        OnLevelUp?.Invoke(_currentLevel);
    }
}
