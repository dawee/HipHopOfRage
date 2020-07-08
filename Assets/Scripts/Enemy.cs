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
