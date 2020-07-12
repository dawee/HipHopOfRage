using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Animator[] healthBar = default;

    [SerializeField]
    private Animator[] bossHealthBar = default;

    [SerializeField]
    private GameObject bossHealthBarContainer = default;

    [SerializeField]
    private Player player = default;

    [SerializeField]
    private Enemy boss = default;

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
        bossHealthBarContainer.SetActive(boss?.gameObject.activeInHierarchy ?? false);
        
        UpdateHpBar(healthBar, player.Health);
        UpdateHpBar(bossHealthBar, (int)(boss?.Health ?? 0));

        if (Input.GetButtonDown("Hit") && (gameOverScreen.activeInHierarchy || winScreen.activeInHierarchy))
        {
            RestartLevel();
        }
    }

    private void UpdateHpBar(Animator[] hpBar, int health)
    {
        int currentHealth = 1;
        foreach (Animator Hp in hpBar)
        {
            if (health >= currentHealth)
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
