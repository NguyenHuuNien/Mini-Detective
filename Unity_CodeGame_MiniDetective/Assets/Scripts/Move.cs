using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speedMove = 350;
    [SerializeField] private float forceJump = 1500;
    [SerializeField] private Animator _animator;
    private LayerMask _layerMaskGround;
    private Rigidbody2D rb;
    private bool isGround;
    private bool isAttack = false;
    private bool isRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _layerMaskGround = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        isGround = checkGround();
        jump();
        attack();
    }

    private void FixedUpdate()
    {
        move();
    }

    private void attack()
    {
        if (Input.GetKeyDown(KeyCode.S)&&!isAttack)
        {
            isAttack = true;
            _animator.SetBool("attack",true);
            Invoke(nameof(resetAttack),0.45f);
        }
        if (!isAttack)
        {
            _animator.SetBool("attack",false);
        }
        else
        {
            _animator.SetFloat("Jump",0);
        }
    }

    private void resetAttack()
    {
        isAttack = false;
    }
    private void jump()
    {
        if (isGround)
        {
            _animator.SetFloat("Jump",0);
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(forceJump * Vector2.up);
            }
        }
        else
        {
            if (isAttack)
            {
                return;
            }
            if (rb.velocity.y > 0)
            {
                _animator.SetFloat("Jump",1);
            }
            else
            {
                _animator.SetFloat("Jump", 2);
            }
        }
    }
    private void move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * speedMove, rb.velocity.y);
            isRight = true;
            if (horizontal > 0)
            {
                isRight = true;
            }else if (horizontal < 0)
            {
                isRight = false;
            }
            transform.localScale = new Vector3(isRight ? 1 : -1,1,1);
        }
        else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        if(isGround)
            _animator.SetFloat("move",Mathf.Abs(horizontal));
    }

    public bool getIsAttack()
    {
        return isAttack;
    }

    public bool getIsRight()
    {
        return isRight;
    }
    private bool checkGround()
    {
        var hit = Physics2D.Raycast(transform.position,Vector3.down,1,_layerMaskGround);
        return hit.collider != null;
    }
}
