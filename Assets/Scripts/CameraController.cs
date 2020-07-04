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
    private Mode mode = Mode.Fixed;

    [SerializeField]
    private Rigidbody2D body = default;

    [SerializeField]
    private float minFollowDistance = default;

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
}
