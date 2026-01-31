using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthCard : LevelUpCard
{
    [SerializeField] private float _healthBonus = 2f;

    public override void Select()
    {
        PlayerStats.Instance.ChangeMaxHealth(_healthBonus);
        base.Select();
    }
}
