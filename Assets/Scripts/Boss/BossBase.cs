using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public enum BossAction
{
    INIT,
    IDLE,
    WALK,
    ATTACK,
    DEATH
}
public class BossBase : MonoBehaviour
{

    public float startAnimationDuration = .5f;
    public float walkDuration = .5f;
    public float attackAnimationDuration = .5f;
    public Ease ease = Ease.OutBack;
    public int attackAmount = 5; 
    public float timeBetweenAttacks = .5f;

    public HealthBase healthBase;
    private StateMachine<BossAction> stateMachine;

    public List<Transform> transforms;

    private Player player;
    private void Awake()
    {
        Init();
        healthBase.OnKill += OnBossKill;
        player = FindObjectOfType<Player>();
    }
    private void Init()
    {
        stateMachine = new StateMachine<BossAction>();
        stateMachine.Init();

        stateMachine.RegisterStates(BossAction.INIT, new BossStateInit());
        stateMachine.RegisterStates(BossAction.WALK, new BossStateWalk());
        stateMachine.RegisterStates(BossAction.ATTACK, new BossStateAttack());
        stateMachine.RegisterStates(BossAction.DEATH, new BossStateDeath());
    }

    private void OnBossKill(HealthBase healthBase)
    {
        stateMachine.SwitchState(BossAction.DEATH);
    }
    
    [NaughtyAttributes.Button]
    private void SwitchInit()
    {
        SwitchState(BossAction.INIT);
    }  
    
    [NaughtyAttributes.Button]
    private void SwitchWalk()
    {
        SwitchState(BossAction.WALK);
    }  
    [NaughtyAttributes.Button]
    private void SwitchAttack()
    {
        SwitchState(BossAction.ATTACK);
        transform.LookAt(player.transform);

    }
    public void SwitchState(BossAction state)
    {
        stateMachine.SwitchState(state, this);
    }

    public void StartInitAnimation()
    {
        transform.DOScale(0, startAnimationDuration).SetEase(ease).From();
    }    

    public void GoToRandomPoint(Action onArrive = null)
    {
        var r = UnityEngine.Random.Range(0, transforms.Count);
        StartCoroutine(GoToPointCoroutine(transforms[r],onArrive));
        transform.LookAt(transforms[r].transform.position);
    }

    IEnumerator GoToPointCoroutine(Transform t, Action onArrive = null)
    {
        while(Vector3.Distance(transform.position, t.position) > 1f)
        {
            transform.DOMove(t.transform.position, walkDuration);
            yield return new WaitForEndOfFrame();
        }
        onArrive?.Invoke();
    }

    public void StartAttack(Action endCallBack = null)
    {
        StartCoroutine(StartAttackCoroutine(endCallBack));
    }

    IEnumerator StartAttackCoroutine(Action endCallBack)
    {
        int attacks = 0;
        while(attacks <= attackAmount)
        {
            attacks++;
            transform.DOMove(player.transform.position, 1);
            transform.DOScale(1.2f, attackAnimationDuration).SetLoops(2, LoopType.Yoyo);
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
        endCallBack?.Invoke();
    }
}
