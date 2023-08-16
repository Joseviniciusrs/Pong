using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    

    public BallBase ballBase;
    public StateMachine stateMachine;
    public  Player player;
    public float timeSetBallFree = 2f;
    public static GameManager Instance;
    public  StateMachine stateMachineEnd;
    

    public Player[] players;

    [Header("Menus")]

    public GameObject UiMainMenu;

    public GameObject UiEndGameMenu;

    private void Awake()
    {
        Instance = this;

        players = FindObjectsOfType<Player>();

        
    }



    private void SetBallFree()
    {
        ballBase.CanMove(true);

    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBallPosition();
        Invoke(nameof(SetBallFree), timeSetBallFree);

    }

    public void ResetPlayers()
    {
        foreach(var player in players)
        {
            player.ResetPlayer();
        }
    }


    public void StartGame()
    {
        ballBase.CanMove(true);
    }
    public void EndGame()
    {
        stateMachineEnd.SwitchState(StateMachine.States.END_GAME);
    }

    public void ShowMainMenu()
    {
        UiMainMenu.SetActive(true);
        ballBase.CanMove(false);

    }

    public void ShowEndGameMenu()
    {
        UiEndGameMenu.SetActive(true);
        ballBase.CanMove(false);
    }

}


