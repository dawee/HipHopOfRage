using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum Mode
    {
        Fixed,
        Following
    }

    [SerializeField]
    private Player player = default;

    [SerializeField]
    private Mode mode = Mode.Following;

    [SerializeField]
    private Rigidbody2D body = default;

    [SerializeField]
    private float minFollowDistance = default;

    [SerializeField]
    private Level level = default;

    public void SetMode(Mode mode)
    {
        this.mode = mode;
    }

    private void Follow()
    {
        if (body.velocity.x > 0 && Mathf.Abs(transform.position.x - player.transform.position.x) <= minFollowDistance)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            body.velocity = Vector2.zero;
        }
        else if ((player.Position.x - transform.position.x) > 0)
        {
            body.velocity = new Vector2(player.Velocity, 0);
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (mode == Mode.Following)
        {
            Follow();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Checkpoint" && level)
        {
            Checkpoint checkpoint = other.GetComponent<Checkpoint>();

            if (!checkpoint.Completed)
            {
                mode = Mode.Fixed;
                level.OnHitCheckpoint(checkpoint);
                body.velocity = Vector2.zero;
            }
        }
    }
}
