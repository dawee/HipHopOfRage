using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body = default;

    [SerializeField]
    private Animator animator = default;

    [SerializeField]
    private float velocity = default;
    public float Velocity => velocity;

    public Vector2 Position => transform.position;

    [SerializeField]
    private int health = default;
    public int Health => health;

    [SerializeField]
    private bool isStun = false;

    [SerializeField]
    private UnityEvent yoDead = default;

    private void Walk()
    {
        float horizontal = Math.Sign(Input.GetAxis("Horizontal"));
        float vertical = Math.Sign(Input.GetAxis("Vertical"));

        if (horizontal < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (horizontal > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        animator.SetBool("Walk", Math.Abs(horizontal) + Math.Abs(vertical) > 0);
        body.velocity = new Vector2(velocity * horizontal, velocity * vertical);
    }

    void Update()
    {
        if (health <= 0)
        {
            return;
        }

        if (Input.GetButtonDown("Hit") && !isStun)
        {
            animator.SetTrigger("Attack1");
        }

        if (isStun)
        {
            body.velocity = Vector2.zero;
        }
        else
        {
            Walk();
        }
    }


    public void ReceiveHit(float damage)
    {
        animator.SetTrigger("hit");
        health -= 1;

        if (health == 0)
        {
            animator.SetBool("Walk", false);
            body.velocity = Vector2.zero;

            yoDead?.Invoke();
        }
    }
}
