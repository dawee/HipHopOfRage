using UnityEngine;

public class Jukebox : MonoBehaviour
{

    [SerializeField]
    private AudioSource levelMusic = default;

    [SerializeField]
    private AudioSource bossMusic = default;

    public void OnEnterBossArea()
    {
        levelMusic.Stop();
        bossMusic.Play();
    }

    public void OnWin()
    {
        levelMusic.Stop();
        bossMusic.Stop();
    }

    public void OnGameOver()
    {
        levelMusic.Stop();
        bossMusic.Stop();
    }

    void Start()
    {
        bossMusic.Stop();
        levelMusic.Play();
    }
}
