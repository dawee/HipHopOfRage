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
    private Player player = default;

    [SerializeField]
    private float minFollowDistance = default;

    [SerializeField]
    private Rigidbody2D body = default;

    [SerializeField]
    private float velocity = default;

    [SerializeField]
    private float health = default;

    private float lastAttack = default;
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

        if (health > 0 && Time.time - lastAttack > 2f)
        {
            animator.SetTrigger("attack");
            lastAttack = Time.time;
        }
    }

    public void ReceiveHit(float damage)
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
