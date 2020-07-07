using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField]
    private HitCollide hit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Hit")){
            hit.Activate();
        }
    }

    public void Hit(float damage)
    {
        print("Ouille");
    }
}
