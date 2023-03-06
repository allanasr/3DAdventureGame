using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ChestBase : MonoBehaviour
{
    public Animator animator;
    public string triggerOpen = "Open";

    public GameObject notification;
    public ChestItemBase itemBase;

    public float animationDuration = .2f;
    public Ease ease = Ease.OutBack;
    private float startScale;

    private bool chestIsOpened = false;
    void Start()
    {
        startScale = notification.transform.localScale.x;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && notification.activeSelf)
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        if (chestIsOpened) return;

        animator.SetTrigger(triggerOpen);
        chestIsOpened = true;

        HideNotification();
        Invoke(nameof(ShowItem), 1f);
    }

    public void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();

        if (p != null)
        {
            ShowNotification();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();

        if (p != null)
        {
            HideNotification();
        }
    }

    private void ShowNotification()
    {
        notification.SetActive(true);
        notification.transform.DOScale(startScale, animationDuration).SetEase(ease);
    }
    private void HideNotification()
    {
        notification.SetActive(false);
    }

    private void ShowItem()
    {
        itemBase.ShowItem();
        Invoke(nameof(CollectItem), 1f);
    }
    private void CollectItem()
    {
        itemBase.Collect();
    }
}
