using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeClothes : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMesh;

    public Texture2D texture;


    public string shaderIdName = "_EmissionMap";

    private Texture2D defaultTexture;


    private void Awake()
    {
       defaultTexture = (Texture2D) skinnedMesh.materials[0].GetTexture(shaderIdName);

    }
    [NaughtyAttributes.Button]

    private void ChangeTexture()
    {
        skinnedMesh.materials[0].SetTexture(shaderIdName, texture);
    }

    public void ChangeTexture(ClothesSetup clothSetup)
    {
        skinnedMesh.materials[0].SetTexture(shaderIdName, clothSetup.texture);

    }
    public void ResetTexture()
    {
        skinnedMesh.materials[0].SetTexture(shaderIdName, defaultTexture);

    }
}
