using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public string _name;

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _enemyBody;
    [SerializeField] private XPOrb _xpOrbPrefab;

    private EntityHealth _entityHealth;
    private NavMeshAgent _agent;
    private GameObject _target;

    private bool _enemyIsDying;

    private void Awake()
    {
        _entityHealth = GetComponent<EntityHealth>();

        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
    }

    private void Start()
    {
        _entityHealth.OnDeath += DestroyEnemy;
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        HandleEnemyMovement();
    }

    private void OnDisable()
    {
        _entityHealth.OnDeath -= DestroyEnemy;
    }
    
    public void HandleEnemyMovement()
    {
        _agent.SetDestination(_target.transform.position);

        bool enemyIsMoving = _agent.velocity.magnitude > 0.1f;
        _animator.SetBool("isMoving", enemyIsMoving);
        
        bool flipSprite = _agent.velocity.x < 0f;
        _enemyBody.flipX = flipSprite;
    }

    public void EnemyDeathSound(string enemyName)
    {
        if (enemyName == "Armless")
        {
            EnemyManager.Instance.OnArmlessDeath();
        }
        else if (enemyName == "Bat")
        {
            EnemyManager.Instance.OnBatDeath();
        }
        else if (enemyName == "Rat")
        {
            EnemyManager.Instance.OnRatDeath();
        }
        else if (enemyName == "Slime")
        {
            EnemyManager.Instance.OnSlimeDeath();
        }
        else
        {
            return;
        }
    }

    public void DestroyEnemy()
    {
        EnemyDeathSound(_name);
        _enemyIsDying = true;
        _animator.SetBool("isDying", _enemyIsDying);
        Instantiate(_xpOrbPrefab, transform.position, Quaternion.identity);
        //EnemyDeathSound(_name);
        //Destroy(gameObject);
        gameObject.SetActive(false);
        //_enemyIsDying = false;
    }
}