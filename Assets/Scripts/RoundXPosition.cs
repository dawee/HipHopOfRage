using UnityEngine;

public class RoundXPosition : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
    }
}
