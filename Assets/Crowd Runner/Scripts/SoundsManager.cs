using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioSource buttonSound; 
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;
    [SerializeField] private AudioSource deathSound;


    // Start is called before the first frame update
    void Start()
    {
        PlayerDetection.onDoorsHit += PlayDoorHitSound;

        GameManager.onGameStateChanged += GameStateChangedCallback;

        Enemy.onRunnerDied += PlayDeathSound;
    }

    private void OnDestroy()
    {
        PlayerDetection.onDoorsHit -= PlayDoorHitSound;

        GameManager.onGameStateChanged -= GameStateChangedCallback;

        Enemy.onRunnerDied -= PlayDeathSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.LevelComplete)
        {
            levelCompleteSound.Play();
        } 
        else if (gameState == GameManager.GameState.GameOver)
        {
            gameOverSound.Play();
        }
    }

    private void PlayDoorHitSound()
    {
        doorHitSound.Play();
    }

    private void PlayDeathSound()
    {
        deathSound.Play();
    }

    public void DisableSounds()
    {
        doorHitSound.volume = 0;
        levelCompleteSound.volume = 0;
        gameOverSound.volume = 0;
        deathSound.volume = 0;
        buttonSound.volume = 0;
    }

    public void EnableSounds ()
    {
        doorHitSound.volume = 1;
        levelCompleteSound.volume = 1;
        gameOverSound.volume = 1;
        deathSound.volume = 1;
        buttonSound.volume = 1;
    }
}
