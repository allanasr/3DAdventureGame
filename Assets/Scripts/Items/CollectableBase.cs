using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public SFXType sfxType;
    public ItemType itemType;
    public ParticleSystem particle;

    [Header("Audio")]

    public AudioSource audioSource;

    public GameObject coin;

    public Collider collider;
    private void Awake()
    {
        if (particle)
        {
            particle.transform.SetParent(null);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        if (collider != null) collider.enabled = false;
        coin.SetActive(false);
        OnCollect();
    }

    private void PlaySfx()
    {
        SFXPool.Instance.Play(sfxType);
    }
    protected virtual void OnCollect()
    {
        if (sfxType == SFXType.NONE) return;
        PlaySfx();
        if(particle != null) particle.Play();
        if (audioSource != null) audioSource.Play();
        CollectableManager.Instance.AddByType(itemType);
    }
}