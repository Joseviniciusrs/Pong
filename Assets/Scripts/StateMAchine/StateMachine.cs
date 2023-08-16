using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    { 
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }

    public Dictionary<States, StateBase> dictionaryState;

    private StateBase _currentState;

    //public Player player;

    public float timeToStart= 1f;

    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;
        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.MENU, gameObject.AddComponent<StateBase>());
        dictionaryState.Add(States.PLAYING, gameObject.AddComponent<StatePlaying>());
        dictionaryState.Add(States.RESET_POSITION, gameObject.AddComponent<StateResetPosition>());
        dictionaryState.Add(States.END_GAME, gameObject.AddComponent<StateEndGame>());


        SwitchState(States.MENU);
    }


    private void StartGame()
    {
        SwitchState(States.MENU);

    }

    public void SwitchState(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];

        if (_currentState != null) _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchState(States.PLAYING);
        }
    }

    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }
}
