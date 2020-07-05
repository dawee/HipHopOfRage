using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private UnityEvent died;

    public void Hit(float damage)
    {
        Die();
    }

    private void Die()
    {
        animator.SetTrigger("death");
        died.Invoke();
    }
}
