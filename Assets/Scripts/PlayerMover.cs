using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private float velocity;

    void Update()
    {
        body.velocity = new Vector2(velocity * Math.Sign(Input.GetAxis("Horizontal")), velocity * Math.Sign(Input.GetAxis("Vertical")));
    }
}
