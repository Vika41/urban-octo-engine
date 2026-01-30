using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStaffController : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _tip;

    [SerializeField] private float _fireRate;

    private float _nextFireTime;

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
        if (Input.GetButton("Fire2") && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + 1f / _fireRate;
            ShootTwo();
        }
    }

    private void RotateStaff()
    {
        SetMousePosition();
        SetLookDirection();
        float angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Shoot()
    {
        //Debug.Log("Bang!");
        Projectile newProjectile = Instantiate(_projectile, _tip.position, Quaternion.identity);
        newProjectile.InitializeProjectile(_lookDirection);
    }

    private void ShootTwo()
    {
        Projectile newProjectile = Instantiate(_projectile, _tip.position, Quaternion.identity);
        newProjectile.InitializeProjectile(_lookDirection);
    }

    private void SetMousePosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void SetLookDirection()
    {
        _lookDirection = (_mousePosition - (Vector2)transform.position).normalized;
    }
}
