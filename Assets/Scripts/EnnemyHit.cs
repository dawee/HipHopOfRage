using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHit : MonoBehaviour
{

    [SerializeField]
    private HitCollide hit;

    void Start()
    {
        StartCoroutine(WaitForHit());
    }

    IEnumerator WaitForHit()
    {
        yield return new WaitForSeconds(2);

        if (enabled)
        {
            hit.Activate();
            StartCoroutine(WaitForHit());
        }
        else
        {
            yield break;
        }
    }
}
