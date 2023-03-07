using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBase : MonoBehaviour, IDamageable
{
    public float startLife = 10f;
    [SerializeField] private float currentLife;

    public bool destroyOnDeath = false;

    public Action<HealthBase> OnKill;
    public Action<HealthBase> OnDamage;

    public List<UIFillUpdater> uiFillUpdater;

    public float damageMultiplier = 1f;
    private void Awake()
    {
        Init();
 
    }

    public void Init()
    {
        ResetLife();
    }
    public void ResetLife()
    {
        currentLife = startLife;
        UpdateGUI();
    }
    protected virtual void Kill()
    {
        if(destroyOnDeath)
            Destroy(gameObject, 3f);

        OnKill?.Invoke(this);
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }
    public void Damage(float f)
    {
        currentLife -= f * damageMultiplier;

        if (currentLife <= 0)
            Kill();
        UpdateGUI();
        OnDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }

    private void UpdateGUI()
    {
        if(uiFillUpdater != null)
        {
            uiFillUpdater.ForEach(i => i.UpdateValue((float)currentLife / startLife));
        }
    }

    public void ChangeDamageMultiplier(float multiplier, float duration)
    {
        StartCoroutine(ChangeDamageMultiplierCoroutine(multiplier, duration));
    }

    IEnumerator ChangeDamageMultiplierCoroutine(float multiplier, float duration)
    {
        damageMultiplier = multiplier;
        yield return new WaitForSeconds(duration);
        damageMultiplier = 1;
    }
}
