using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Animator[] healthBar;

    [SerializeField]
    private Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int Health = player.Health;
        int currentHealth = 1;
        foreach (Animator Hp in healthBar)
        {
            if (Health >= currentHealth)
            {
                Hp.SetBool("Full", true);
            }
            else
            {
                Hp.SetBool("Full", false);
            }
            currentHealth++;
        }
    }
}
