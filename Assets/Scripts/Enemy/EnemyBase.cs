using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyBase : MonoBehaviour , IDamageable
{
    public float startLife = 10f;

    public FlashColor flashColor;
    public Collider collider;
    public ParticleSystem particleSystem;

    [SerializeField] private AnimationBase animationBase;
    [SerializeField] private float currentLife;

    [Header("Start Animation")]
    public float startAnimationDuration = .2f;
    public Ease ease = Ease.OutBack;
    public bool startWithSpawnAnimation = true;

    private void Awake()
    {
        Init();
    }

    protected void ResetLife()
    {
        currentLife = startLife;
    }
    protected virtual void Init()
    {
        ResetLife();
        SpawnAnimation();
    }
    protected virtual void Kill()
    {
        OnKill();
    }

    protected virtual void OnKill()
    {
        if (collider != null) collider.enabled = false;
        Destroy(gameObject, 3f);
        PlayAnimationByTrigger(AnimationType.DEATH);
    }

    public void OnDamage(float f)
    {
        if (flashColor != null) flashColor.Flash();
        if (particleSystem != null) particleSystem.Play();

        currentLife -= f;

        if (currentLife <= 0)
            Kill();
    }

    private void SpawnAnimation()
    {
        transform.DOScale(0, startAnimationDuration).From().SetEase(ease);
    }

    public void PlayAnimationByTrigger(AnimationType animationType)
    {
        animationBase.PlayerAnimationByTrigger(animationType);
    }

    public void Damage(float damage)
    {
        OnDamage(damage);
    }
}
