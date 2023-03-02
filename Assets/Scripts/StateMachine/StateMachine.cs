using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class StateMachine<T> where T : System.Enum
{

    public Dictionary<T, StateBase> dictionaryState;

    private StateBase currentState;

    public StateBase CurrentState
    {
        get { return currentState; }
    }

    public void Init()
    {
        dictionaryState = new Dictionary<T, StateBase>();
    }
    public void RegisterStates(T typeEnum, StateBase stateBase)
    {
        dictionaryState.Add(typeEnum, stateBase);
    }

    public void SwitchState(T state, object o = null)
    {
        if (currentState != null) currentState.OnStateExit();

        currentState = dictionaryState[state];
        currentState.OnStateEnter(o);
    }

    private void Update()
    {
        if (currentState != null) currentState.OnStateStay();

        //if (Input.GetKeyDown(KeyCode.O))
            //SwitchState(States.DEAD);
    }

}

