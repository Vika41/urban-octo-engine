using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCard : LevelUpCard
{
    [SerializeField] private float _damageBonus = 0.2f;

    public override void Select()
    {
        PlayerStats.Instance.ChangeDamage(_damageBonus);
        base.Select();
    }
}
