using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    public enum State
    {
        FollowingPlayer,
        AvoidingOtherEnemy
    }

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

    [SerializeField]
    private bool isStun = false;

    private State state = State.FollowingPlayer;
    private Enemy otherEnemyToAvoid = default;
    private float lastAttack = default;
    private static Vector3 rightScale = new Vector3(1, 1, 1);
    private static Vector3 leftScale = new Vector3(-1, 1, 1);

    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > minFollowDistance)
        {
            transform.localScale = player.transform.position.x > transform.position.x ? rightScale : leftScale;
            body.velocity = (player.transform.position - transform.position).normalized * velocity;
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }

    private void AvoidOtherEnemy()
    {
        body.velocity = (transform.position - otherEnemyToAvoid.transform.position).normalized * velocity;
        transform.localScale = body.velocity.x > 0 ? rightScale : leftScale;
    }

    private void Stun()
    {
        body.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (isStun)
        {
            Stun();
        }
        else
        {
            UpdateActions();
        }
    }

    private void UpdateActions()
    {
        switch (state)
        {
            case State.FollowingPlayer:
                FollowPlayer();
                break;
            case State.AvoidingOtherEnemy:
                AvoidOtherEnemy();
                break;
        }

        animator.SetBool("walk", body.velocity != Vector2.zero);

        if (health > 0 && Time.time - lastAttack > 2f && Vector3.Distance(transform.position, player.transform.position) <= minFollowDistance)
        {
            animator.SetTrigger("attack");
            lastAttack = Time.time;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            state = State.FollowingPlayer;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            otherEnemyToAvoid = other.GetComponent<Enemy>();
            state = State.AvoidingOtherEnemy;
        }
    }

    public void ReceiveHit(float damage)
    {
        health -= 1;

        if (health == 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("hit");
        }
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
