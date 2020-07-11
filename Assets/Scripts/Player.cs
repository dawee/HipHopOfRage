using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float velocity;
    public float Velocity => velocity;

    public Vector2 Position => transform.position;

    [SerializeField]
    private int health = default;
    public int Health => health;

    [SerializeField]
    private bool isStun = false;

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
    }
}
