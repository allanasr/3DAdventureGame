using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructableObjectsBase : MonoBehaviour
{
    public HealthBase healthBase;

    public float shakeDuration = .1f;
    public int shakeForce = 1;

    public int dropCoinsAmount = 10;

    public GameObject coinPrefab;
    public Transform dropPosition;
    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();

    }

    private void Awake()
    {
        OnValidate( );
        healthBase.OnDamage += OnDamage;
    }

    private void OnDamage(HealthBase health)
    {
        transform.DOShakeScale(.1f, Vector3.up, 5);
        DropCoins();
    }

    private void DropCoins()
    {
        var i = Instantiate(coinPrefab);
        i.transform.position = dropPosition.position;
    }
}
