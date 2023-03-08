using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    
    public Color color = Color.white;
    public float duration = 1f;

    private Color defaultColor;

    private Tween currentTween;

    public string colorParameter = "_EmissionColor";

    private void OnValidate()
    {
        if (meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();
        if (skinnedMeshRenderer == null) skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }
    private void Start()
    {
    }
    [NaughtyAttributes.Button]
    public void Flash()
    {
        if(meshRenderer != null && !currentTween.IsActive())
            currentTween = meshRenderer.material.DOColor(color, colorParameter, duration).SetLoops(2, LoopType.Yoyo); 
        
        if(skinnedMeshRenderer != null && !currentTween.IsActive())
            currentTween = skinnedMeshRenderer.material.DOColor(color, colorParameter, duration).SetLoops(2, LoopType.Yoyo);
    }
}
