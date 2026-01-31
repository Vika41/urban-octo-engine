using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegenCard : LevelUpCard
{
    [SerializeField] private float _regenBonus = 0.5f;

    public override void Select()
    {
        PlayerStats.Instance.ChangeHealthRegen(_regenBonus);
        base.Select();
    }
}
