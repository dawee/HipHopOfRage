using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Animator animator = default;

    [SerializeField]
    private Wave wave = default;

    [SerializeField]
    private PlayerMover player = default;

    [SerializeField]
    private float minFollowDistance = default;

    [SerializeField]
    private Rigidbody2D body = default;

    [SerializeField]
    private float velocity = default;

    private static Vector3 rightScale = new Vector3(1, 1, 1);
    private static Vector3 leftScale = new Vector3(-1, 1, 1);

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > minFollowDistance)
        {
            transform.localScale = player.transform.position.x > transform.position.x ? rightScale : leftScale;
            body.velocity = (player.transform.position - transform.position).normalized * velocity;
            animator.SetBool("walk", true);
        }
        else
        {
            body.velocity = Vector2.zero;
            animator.SetBool("walk", false);
        }
    }

    public void Hit(float damage)
    {
        Die();
    }

    private void Die()
    {
        animator.SetTrigger("death");

        if (wave)
        {
            wave.OnEnemyDead(this);
        }
    }
}
