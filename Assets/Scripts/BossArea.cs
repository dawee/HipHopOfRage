using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour
{

    [SerializeField]
    private Jukebox jukebox = default;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            jukebox.OnEnterBossArea();
        }
    }

}
