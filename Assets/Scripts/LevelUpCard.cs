using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public abstract class LevelUpCard : MonoBehaviour
{
    [SerializeField] private AudioClip _powerupSFX;

    private LevelUpPanel _levelUpPanel;

    public virtual void Select()
    {
        AudioManager.Instance.PlayAudio(_powerupSFX, SoundType.SFX, 0.5f, false);
        _levelUpPanel.ClosePanel();
    }

    public virtual void SetLevelUpPanel(LevelUpPanel levelUpPanel)
    {
        _levelUpPanel = levelUpPanel;
    }
}
