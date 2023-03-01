using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIGunUpdater : MonoBehaviour
{
    public Image uiImage;

    public float animationDuration = 0.5f;
    public Ease ease = Ease.OutBounce;

    private Tween currentTween;
    private void OnValidate()
    {
        if (uiImage == null) uiImage = GetComponent<Image>();
    }
    public void UpdateValue(float f)
    {
        uiImage.fillAmount = f;

    } 
    public void UpdateValue(float max,float current)
    {
        if (currentTween != null) currentTween.Kill();
            uiImage.DOFillAmount(1 - (current / max), animationDuration).SetEase(ease);

    }
}
