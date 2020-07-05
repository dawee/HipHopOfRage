using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void Hit(float damage)
    {
        animator.SetTrigger("death");
    }
}
