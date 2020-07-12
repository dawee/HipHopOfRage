using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Animator[] healthBar = default;

    [SerializeField]
    private Player player = default;

    [SerializeField]
    private GameObject winScreen = default;

    [SerializeField]
    private GameObject gameOverScreen = default;

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

        if (Input.GetButtonDown("Hit") && (gameOverScreen.activeInHierarchy || winScreen.activeInHierarchy))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void OnPlayerDead()
    {
        gameOverScreen.SetActive(true);
    }

    public void OnAllEnemiesDead()
    {
        winScreen.SetActive(true);
    }
}
