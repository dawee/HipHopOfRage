using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField]
    private List<Wave> waves = default;

    [SerializeField]
    private Level level = default;

    private bool completed = false;
    public bool Completed => completed;

    public void OnWaveCompleted(Wave wave)
    {
        waves.Remove(wave);

        if (waves.Count == 0 && !completed)
        {
            Complete();
        }
    }

    private void Complete()
    {
        completed = true;
        level.OnCompleteCheckpoint(this);
    }

}
