using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    [SerializeField]
    private bool started = false;

    [SerializeField]
    private bool completed = false;

    [SerializeField]
    private List<Enemy> enemies = default;

    public void OnEnemyDead(Enemy enemy)
    {
        enemies.Remove(enemy);

        if (enemies.Count == 0 && !completed)
        {
            CompleteWave();
        }
    }

    private void Start()
    {
        foreach (var enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!started && other.tag == "Player")
        {
            StartWave();
        }
    }

    private void CompleteWave()
    {
        completed = true;
    }

    private void StartWave()
    {
        foreach (var enemy in enemies)
        {
            enemy.gameObject.SetActive(true);
        }

        started = true;
    }
}
