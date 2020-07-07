using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHit : MonoBehaviour
{

    [SerializeField]
    private HitCollide hit;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForHit());
    }

    IEnumerator WaitForHit() {
        yield return new WaitForSeconds(2);
        hit.Activate();
        StartCoroutine(WaitForHit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
