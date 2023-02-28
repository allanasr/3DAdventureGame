using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMExample : MonoBehaviour
{
    public enum ExampleEnum
    {
        STATEONE,
        STATETWO,
        STATETHREE
    }

    public StateMachine<ExampleEnum> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<ExampleEnum>();
        stateMachine.Init();
        stateMachine.RegisterStates(ExampleEnum.STATEONE, new StateBase());
        stateMachine.RegisterStates(ExampleEnum.STATETWO, new StateBase());

        stateMachine.SwitchState(ExampleEnum.STATEONE);
    }
}
