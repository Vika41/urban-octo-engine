using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _travelSpeed;
    [SerializeField] private float dmg;

    private BulletImpactController bic;

    public void InitializeProjectile(Vector2 direction)
    {
        Launch(direction);
    }

    private void Launch(Vector2 direction)
    {
        Vector2 movement = direction.normalized * _travelSpeed;
        _rb.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DealDamage(collision.gameObject);
            bic.DestroyBullet();
            DestroyProjectile();
        }
        
        if (collision.gameObject.CompareTag("Terrain"))
        {
            bic.DestroyBullet();
            DestroyProjectile();
        }
    }

    private void DealDamage(GameObject target)
    {
        if (target.TryGetComponent(out EntityHealth entityHealth))
        {
            entityHealth.LoseHealth(dmg);
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
