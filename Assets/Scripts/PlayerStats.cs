using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public static PlayerStats Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeMaxHealth(float maxHealth)
    {
        if (_player.TryGetComponent(out EntityHealth entityHealth))
        {
            entityHealth.GainMaxHealth(maxHealth);
        }
    }

    public void ChangeSpeed(float speed)
    {
        if (_player.TryGetComponent(out PlayerController _movementSpeed))
        {
            _movementSpeed.GainSpeed(speed);
        }
    }

    public void ChangeFirerate(float fireRate) 
    {
        if (_player.TryGetComponent(out PlayerStaffController playerStaffController))
        {
            playerStaffController.GainFireRate(fireRate);
        }
    }

    public void ChangeDamage(float damage)
    {
        if (_player.TryGetComponent(out PlayerStaffController playerStaffController))
        {
            playerStaffController.GainDamage(damage);
        }
    }

    public void ChangeHealthRegen(float healthRegen)
    {
        if (_player.TryGetComponent(out EntityHealth entityHealth))
        {
            entityHealth.SetHealthRegen(healthRegen);
        }
    }
}
