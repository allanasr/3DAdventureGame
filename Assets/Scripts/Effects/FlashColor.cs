using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    public Color color = Color.white;
    public float duration = 1f;

    private Color defaultColor;

    private Tween currentTween;

    private void Start()
    {
        defaultColor = meshRenderer.material.GetColor("_EmissionColor");
    }
    [NaughtyAttributes.Button]
    public void Flash()
    {
        if(!currentTween.IsActive())
            currentTween = meshRenderer.material.DOColor(color, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
    }
}
