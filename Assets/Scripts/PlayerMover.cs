using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float velocity;
    public float Velocity => velocity;

    public Vector2 Position => transform.position;

    void Start()
    {
        
    }

    void Update()
    {
        
        float horizontal = Math.Sign(Input.GetAxis("Horizontal"));
        float vertical = Math.Sign(Input.GetAxis("Vertical"));
        animator.SetBool("Walk", Math.Abs(horizontal) + Math.Abs(vertical) > 0);

        body.velocity = new Vector2(velocity * horizontal, velocity * vertical);
    }
}
