 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.PackageManager;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameState { Menu, Game, LevelComplete, GameOver }
    
    private GameState gameState;

    public static Action<GameState> onGameStateChanged;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else 
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);

        Debug.Log("Game State Changed to : " + gameState);
    }

    public bool IsGameState()
    {
        return gameState == GameState.Game;
    }
}