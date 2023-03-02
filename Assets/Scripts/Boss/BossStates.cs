using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateBase : StateBase
{
    protected BossBase boss;

    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        boss = (BossBase)o;
    }
}

public class BossStateInit : BossStateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        boss.StartInitAnimation();
    }
}

public class BossStateWalk : BossStateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        boss.GoToRandomPoint(OnArrive);
    }

    private void OnArrive()
    {
        //boss.SwitchState(BossAction.ATTACK);
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        boss.StopAllCoroutines();
    }

}

public class BossStateAttack : BossStateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        boss.StartAttack(EndAttacks);
    }

    private void EndAttacks()
    {
        boss.SwitchState(BossAction.WALK);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        boss.StopAllCoroutines();
    }
}

public class BossStateDeath : BossStateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        boss.transform.localScale = Vector3.one;
    }


}
