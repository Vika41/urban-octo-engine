using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static AudioManager;
using static EnemyManager;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject _hitParticlePrefab;
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _travelSpeed;
    [SerializeField] private float _damage;

    //private BulletImpactController bic;
    private AudioClip _bulletImpactSFX;

    public void InitializeProjectile(Vector2 direction)
    {
        Launch(direction);
    }

    private void Launch(Vector2 direction)
    {
        Vector2 movement = direction.normalized * _travelSpeed;
        _rb.velocity = movement;
    }

    private void DamageSound(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy._name == "Armless")
            {
                EnemyManager.Instance.OnArmlessDamage();
            }
            else if (enemy._name == "Bat")
            {
                EnemyManager.Instance.OnBatDamage();
            }
            else if (enemy._name == "Rat")
            {
                EnemyManager.Instance.OnRatDamage();
            }
            else if (enemy._name == "Slime")
            {
                EnemyManager.Instance.OnSlimeDamage();
            }
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DealDamage(collision.gameObject);
            DamageSound(collision.gameObject);
            //bic.DestroyBullet();
            DestroyProjectile();
        }
        
        if (collision.gameObject.CompareTag("Terrain"))
        {
            //AudioManager.Instance.PlayAudio(_bulletImpactSFX, SoundType.SFX, 0.5f, false);
            //bic.DestroyBullet();
            DestroyProjectile();
        }
    }

    private void DealDamage(GameObject target)
    {
        if (target.TryGetComponent(out EntityHealth entityHealth))
        {
            entityHealth.LoseHealth(_damage);
        }
    }

    private void DestroyProjectile()
    {
        GameObject hitParticles = Instantiate(_hitParticlePrefab, transform.position, Quaternion.identity);
        Destroy(hitParticles, 1f);

        Destroy(gameObject);
    }
}