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

    void Start()
    {
        bossMusic.Stop();
        levelMusic.Play();
    }
}
