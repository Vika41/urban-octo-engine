using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCard : LevelUpCard
{
    [SerializeField] private float _speedBonus = 0.5f;

    public override void Select()
    {
        PlayerStats.Instance.ChangeSpeed(_speedBonus);
        base.Select();
    }
}
