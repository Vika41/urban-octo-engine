using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrbPicker : MonoBehaviour
{
    [SerializeField] private float _attractDistance = 1.0f;

    [SerializeField] private LayerMask _xpOrbLayer;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _attractDistance, _xpOrbLayer);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent(out XPOrb xpOrb))
            {
                xpOrb.SetTarget(this.gameObject);
            }
        }
    }
}
