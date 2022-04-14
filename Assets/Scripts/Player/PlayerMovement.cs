using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

internal enum PlayerState
{
    Idle,
    Running,
    Jumping,
    Falling
}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;


    private static readonly int State = Animator.StringToHash("PlayerState");

    private float _dirX = 0f;

    [FormerlySerializedAs("MoveSpeed")] [SerializeField]
    private float moveSpeed = 10f;

    [FormerlySerializedAs("JumpForce")] [SerializeField]
    private float jumpForce = 20f;

    [SerializeField] private LayerMask jumpableGround;
    private bool _canDoubleJump = true;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        RunLogic();
        JumpLogic();
        RunningAnimation();
    }

    private void RunLogic()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.velocity = new Vector2(_dirX * moveSpeed, _rigidbody2D.velocity.y);
    }

    private void JumpLogic()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            _canDoubleJump = true;
        }
        else if (Input.GetButtonDown("Jump") && _canDoubleJump)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            _canDoubleJump = false;
        }
    }

    private void RunningAnimation()
    {
        PlayerState playerState;
        playerState = PlayerState.Idle;
        if (_dirX > 0f)
        {
            playerState = PlayerState.Running;
            _spriteRenderer.flipX = false;
        }
        else if (_dirX < 0f)
        {
            playerState = PlayerState.Running;
            _spriteRenderer.flipX = true;
        }
        else
        {
            playerState = PlayerState.Idle;
        }

        if (_rigidbody2D.velocity.y > .1f)
        {
            playerState = PlayerState.Jumping;
        }
        else if (_rigidbody2D.velocity.y < -.1f)
        {
            playerState = PlayerState.Falling;
        }

        _animator.SetInteger(State, (int) playerState);
    }

    private bool IsGrounded()
    {
        var bounds = _boxCollider2D.bounds;
        return Physics2D.BoxCast(bounds.center
            , bounds.size
            , 0f
            , Vector2.down
            , .1f
            , jumpableGround);
    }
}