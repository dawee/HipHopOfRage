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
    private PlayerMover player = default;

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
        if (Mathf.Abs(transform.position.x - player.Position.x) <= minFollowDistance)
        {
            transform.position = new Vector3(player.Position.x, transform.position.y, transform.position.z);
            body.velocity = Vector2.zero;
        }
        else
        {
            body.velocity = new Vector2(
                Math.Sign(player.Position.x - transform.position.x) * player.Velocity,
                0
            );
        }
    }

    private void Update()
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
            mode = Mode.Fixed;

            Checkpoint checkpoint = other.GetComponent<Checkpoint>();
            level.OnHitCheckpoint(checkpoint);
        }
    }
}
