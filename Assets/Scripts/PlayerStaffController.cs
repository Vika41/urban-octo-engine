using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static AudioManager;

public class PlayerStaffController : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _tip;

    [SerializeField] private float _fireRate;
    [SerializeField] private float _powerFireRate;

    [SerializeField] private AudioClip _fireProjectiles;

    private float _nextFireTime;
    private float _nextPowerFireTime;

    private Vector2 _mousePosition;
    private Vector2 _lookDirection;

    void Update()
    {
        SetMousePosition();
        SetLookDirection();
        RotateStaff();
        if (Input.GetButton("Fire1") && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + 1f / _fireRate;
            Shoot();
        }
        
        if (Input.GetButton("Fire2") && Time.time >= _nextPowerFireTime)
        {
            _nextPowerFireTime = Time.time + 1f / _powerFireRate;
            PowerShoot();
        }
    }

    private void RotateStaff()
    {
        float angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Shoot()
    {
        //Debug.Log("Bang!");

        AudioManager.Instance.PlayAudio(_fireProjectiles, SoundType.SFX, 0.5f, false);

        Projectile newProjectile = Instantiate(_projectile, _tip.position, Quaternion.identity);
        newProjectile.InitializeProjectile(_lookDirection);
    }

    private void PowerShoot()
    {
        AudioManager.Instance.PlayAudio(_fireProjectiles, SoundType.SFX, 0.5f, false);

        Projectile newProjectile1 = Instantiate(_projectile, _tip.position, Quaternion.identity);
        newProjectile1.InitializeProjectile(Quaternion.Euler(0, 0, -15) * _lookDirection);

        AudioManager.Instance.PlayAudio(_fireProjectiles, SoundType.SFX, 0.5f, false);

        Projectile newProjectile2 = Instantiate(_projectile, _tip.position, Quaternion.identity);
        newProjectile2.InitializeProjectile(_lookDirection);

        AudioManager.Instance.PlayAudio(_fireProjectiles, SoundType.SFX, 0.5f, false);

        Projectile newProjectile3 = Instantiate(_projectile, _tip.position, Quaternion.identity);
        newProjectile3.InitializeProjectile(Quaternion.Euler(0, 0, 15) * _lookDirection);
    }

    private void SetMousePosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void SetLookDirection()
    {
        _lookDirection = (_mousePosition - (Vector2)transform.position).normalized;
    }

    public void GainFireRate(float fireRate)
    {
        _fireRate += fireRate;
    }

    public void GainDamage(float damage)
    {
        _projectile.GetType().GetProperty("Damage")?.SetValue(_projectile, damage);
    }
}
