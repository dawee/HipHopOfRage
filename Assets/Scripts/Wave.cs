using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> enemies = default;

    [SerializeField]
    private Checkpoint checkpoint = default;

    private bool started = false;
    private bool completed = false;
    public bool Completed => completed;

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

        if (checkpoint)
        {
            checkpoint.OnWaveCompleted(this);
        }
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
