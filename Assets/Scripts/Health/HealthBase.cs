using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBase : MonoBehaviour
{
    public float startLife = 10f;
    [SerializeField] private float currentLife;

    public bool destroyOnDeath = false;

    public Action<HealthBase> OnKill;
    public Action<HealthBase> OnDamage;
    protected void ResetLife()
    {
        currentLife = startLife;
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
        currentLife -= f;

        if (currentLife <= 0)
            Kill();
        OnDamage?.Invoke(this);
    }
}
