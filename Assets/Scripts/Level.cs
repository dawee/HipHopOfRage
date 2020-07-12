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
    private Wave[] waves;

    private void Awake()
    {
        // Unoptimized, lazy version because end of jam (ideally we would link them in the editor instead of using reflection)
        waves = FindObjectsOfType<Wave>().Where(w => w.gameObject.activeInHierarchy).ToArray();
    }

    public void OnHitCheckpoint(Checkpoint checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void OnCompleteCheckpoint(Checkpoint checkpoint)
    {
        if (checkpoint == currentCheckpoint)
        {
            if (waves.All(w => w.Completed))
            {
                AllWavesCompleted?.Invoke();
                return;
            }
            
            currentCheckpoint = null;
            cameraController.SetMode(CameraController.Mode.Following);
            handgunAnimator.SetTrigger("show");
        }
    }

}
