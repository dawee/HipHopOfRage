using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollide : MonoBehaviour
{

    public enum Target
    {
        Enemy,
        Player
    }

    [SerializeField]
    private float damage = default;

    [SerializeField]
    private Target target = default;

    [SerializeField]
    private float hitYRange = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsHitSuccessful(other))
        {
            if (target == Target.Enemy && other.tag == "Enemy")
            {
                Enemy enemy = other.GetComponent<Enemy>();

                enemy.ReceiveHit(1.0f);
            }
            else if (target == Target.Player && other.tag == "Player" && other.isTrigger)
            {
                Player player = other.GetComponent<Player>();

                player.ReceiveHit(damage);
            }
        }
    }

    private bool IsHitSuccessful(Collider2D other)
    {
        var distance = Math.Abs(transform.parent.position.y - other.transform.position.y);
        return distance <= hitYRange;
    }
}
