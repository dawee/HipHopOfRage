using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Animator[] HealthBar;

    [SerializeField]
    private PlayerHit Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int Health = Player.GetHealth();
        int currentHealth = 1;
        foreach (Animator Hp in HealthBar) {
            if(Health >= currentHealth) {
                Hp.SetBool("Full", true);
            } else {
                Hp.SetBool("Full", false);
            }
            currentHealth++;
        }
    }
}
