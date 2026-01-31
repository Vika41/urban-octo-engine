using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class XPOrb : MonoBehaviour
{
    [SerializeField] private int _xpAmount = 1;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _pickupDistance = 0.5f;
    [SerializeField] private AudioClip _xpSFX;

    private GameObject _target;

    private void Update()
    {
        if (_target == null)
        {
            return;
        }

        Vector2 direction = _target.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * _speed * Time.deltaTime);

        if (Vector2.Distance(_target.transform.position, transform.position) < _pickupDistance)
        {
            GrantXP();
        }
    }

    private void GrantXP()
    {
        LevelUpManager.Instance.GetXP(_xpAmount);
        AudioManager.Instance.PlayAudio(_xpSFX, SoundType.SFX, 0.8f, false);
        Destroy(gameObject);
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}
