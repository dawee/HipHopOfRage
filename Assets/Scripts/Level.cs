using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField]
    private CameraController cameraController;

    private Checkpoint currentCheckpoint;

    public void OnHitCheckpoint(Checkpoint checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void OnCompleteCheckpoint(Checkpoint checkpoint)
    {
        if (checkpoint == currentCheckpoint)
        {
            currentCheckpoint = null;
            cameraController.SetMode(CameraController.Mode.Following);
        }
    }

}
