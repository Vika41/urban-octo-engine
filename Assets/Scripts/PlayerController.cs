using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _characterBody;
    [SerializeField] private float _movementSpeed;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * _movementSpeed;
        _rb.velocity = movement;

        bool characterIsWalking = movement.magnitude > 0f;
        _animator.SetBool("isWalking", characterIsWalking);

        bool flipSprite = movement.x < 0f;
        _characterBody.flipX = flipSprite;
    }

    public void HandleDeath()
    {
        bool characterIsDying = true;
        _animator.SetBool("isDying", characterIsDying);
        GameManager.Instance.GameOver();
    }

    public void GainSpeed(float speedIncrease)
    {
        _movementSpeed += speedIncrease;
    }
}
