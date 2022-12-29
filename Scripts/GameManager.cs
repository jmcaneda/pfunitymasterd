using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int nextScene;
    private bool b1,b2;
    public float startTime;
    public float gameTime;
    public int parcialPuntos;

    PlayerController player;
    UIController uiController;

    [SerializeField] byte fruitsOnLevel;
    public byte FruitsOnLevel
    {
        get { return fruitsOnLevel; }
        set
        {
            fruitsOnLevel = value;

            if (fruitsOnLevel == 0)
            {
                Debug.Log("Has ganado el nivel");
                GameFinished = true;
                GameStarted= false;
                uiController.ActivateWinnerPanel();
            }
        }
    }

    [SerializeField] byte playersLives;
    public byte PlayersLives
    {
        get
        {
            return playersLives;
        }
        set
        {
            playersLives = value;
            if (playersLives == 0)
            {
                Debug.Log("Has perdido el nivel");
                GameFinished = true;
                GameStarted = false;
                uiController.ActivateLosePanel();
            }
            uiController.UpdateUILives(playersLives);
        }
    }

    [SerializeField] byte enemigosOnLevel;
    public byte EnemigosOnLevel
    {
        get { return enemigosOnLevel; }
        set { enemigosOnLevel = value; }
    }

    [SerializeField] bool gameStarted;
    public bool GameStarted
    {
        get
        {
            return gameStarted;
        }
        set
        {
            gameStarted = value;
        }
    }
    [SerializeField] bool gameFinished;
    public bool GameFinished
    {
        get
        {
            return gameFinished;
        }
        set
        {
            gameFinished = value;
        }
    }
    [SerializeField] bool endGame;
    public bool EndGame
    {
        get
        {
            return endGame;
        }
        set
        {
            endGame = value;
        }
    }
    [SerializeField] bool gamePause;
    public bool GamePause
    {
        get
        {
            return gamePause;
        }
        set
        {
            gamePause = value;
        }
    }
    private void Awake()
    {
        uiController = FindObjectOfType<UIController>();
        nextScene = uiController.sceneIndex + 1;
        b1= true;
        b2= true;
        PlayersLives = 1;
        parcialPuntos = ControladorMarcadores.instance.CantidadPuntos;
    }
    private void Start()
    {
        if (!gameStarted) 
        {
            gameStarted = true;
        }
        startTime = Time.time;
    }

    private void Update()
    {
        gameTime = Time.time - startTime;
        switch (FruitsOnLevel) 
         {
            case 10:
                {
                    if (b1)
                    {
                        PlayersLives += 1;
                        b1= false;
                    }
                    break;
                }
             case 5: 
                {
                    if (b2)
                    {
                        PlayersLives += 1;
                        b2 = false;
                    }
                    break;
                }
            default: { break; }
         }
    }
   
}
