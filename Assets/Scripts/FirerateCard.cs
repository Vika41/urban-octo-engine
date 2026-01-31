using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirerateCard : LevelUpCard
{
    [SerializeField] private float _firerateBonus = 0.2f;

    public override void Select()
    {
        PlayerStats.Instance.ChangeFirerate(_firerateBonus);
        base.Select();

    }
}
