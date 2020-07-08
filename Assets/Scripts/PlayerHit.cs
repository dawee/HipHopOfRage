using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField]
    private HitCollide hit;

    [SerializeField]
    private int Health;
    
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

    public int GetHealth() {
        return Health;
    }

    public void Hit(float damage)
    {
        Health -= 1;
    }
}
