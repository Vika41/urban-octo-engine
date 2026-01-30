using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class BulletImpactController : MonoBehaviour
{
    [SerializeField] private GameObject _hitParticlePrefab;

    private List<AudioClip> _bulletImpacts = new List<AudioClip>();
    
    public void DestroyBullet()
    {
        AudioClip randomBulletImpact = _bulletImpacts[Random.Range(0, _bulletImpacts.Count)];
        AudioManager.Instance.PlayAudio(randomBulletImpact, SoundType.SFX, 0.5f, false);

        GameObject hitParticles = Instantiate(_hitParticlePrefab, transform.position, Quaternion.identity);
        Destroy(hitParticles, 1f);

        Destroy(gameObject);
    }
}
