using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController = default;

    [SerializeField]
    private Animator handgunAnimator = default;

    [SerializeField]
    private UnityEvent AllWavesCompleted = default;

    private Checkpoint currentCheckpoint;
    private Checkpoint[] checkpoints;

    private bool completed = false;

    private void Awake()
    {
        // Unoptimized, lazy version because end of jam (ideally we would link them in the editor instead of using reflection)
        checkpoints = FindObjectsOfType<Checkpoint>().Where(c => c.gameObject.activeInHierarchy).ToArray();
    }

    public void OnHitCheckpoint(Checkpoint checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void OnCompleteCheckpoint(Checkpoint checkpoint)
    {
        if (checkpoints.All(c => c.Completed) && !completed)
        {
            completed = true;
            AllWavesCompleted?.Invoke();
            return;
        }

        if (checkpoint == currentCheckpoint)
        {
            currentCheckpoint = null;
            cameraController.SetMode(CameraController.Mode.Following);
            handgunAnimator.SetTrigger("show");
        }
    }

}
