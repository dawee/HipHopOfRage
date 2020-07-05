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
        animator.SetTrigger("Walk");
    }

    void Update()
    {
        body.velocity = new Vector2(velocity * Math.Sign(Input.GetAxis("Horizontal")), velocity * Math.Sign(Input.GetAxis("Vertical")));
    }
}
