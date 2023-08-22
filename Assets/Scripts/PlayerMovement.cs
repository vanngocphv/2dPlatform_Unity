using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float _jumpHeight = 7f;
    public float _moveSpeed = 5f;
    public SpriteRenderer spriteRenderer;
    public LayerMask _groundLayer;
    public AudioSource _audioSource;

    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    private float dirX;

    private bool isJumping = false;
    private bool isDead = false;

    //Animation State
    private enum AnimationState
    {
        Idle,
        Running,
        Jumping,
        Faling
    }


    private void Start()
    {
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        animator = this.GetComponent<Animator>();
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDead) return;
        dirX = Input.GetAxisRaw("Horizontal");
        if (dirX != 0)
        {
            rigid.velocity = new Vector2(_moveSpeed * dirX, rigid.velocity.y);
            spriteRenderer.flipX = dirX < 0 ? true : false;
        }
        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            _audioSource.Play();
            rigid.velocity = new Vector2(rigid.velocity.x, _jumpHeight);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuUI.instance.ActiveObject();
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        AnimationState state = AnimationState.Idle;
        if (dirX != 0)
        {
            state = AnimationState.Running;
            rigid.velocity = new Vector2(_moveSpeed * dirX, rigid.velocity.y);
            spriteRenderer.flipX = dirX < 0 ? true : false;
        }
        if (rigid.velocity.y > 0.1f)
        {
            state = AnimationState.Jumping;
        }
        if (rigid.velocity.y < -0.1f)
        {
            state = AnimationState.Faling;
        }


        
        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        if (Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, _groundLayer))
        {
            return true;
        }
        return false;
        
    }



    public void IsDead(bool flag)
    {
        isDead= flag;
    }
}
