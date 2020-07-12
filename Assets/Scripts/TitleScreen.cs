using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{

    [SerializeField]
    private GameObject game = default;
    
    [SerializeField]
    private GameObject titleScreen = default;

    [SerializeField]
    private Animator animator = default;

    [SerializeField]
    private bool isStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        game.SetActive(true);
        titleScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Hit"))
        {
            animator.SetTrigger("start");
        }
        if(isStarted)
        {
            StartGame();
        }
    }
}
