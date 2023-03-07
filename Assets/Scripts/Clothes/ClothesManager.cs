using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
public enum ClothType
    {
        SPEED,
        STRENGTH,
        APPEARANCE
    }
public class ClothesManager : Singleton<ClothesManager>
{
    public List<ClothesSetup> clothesSetups;
    
    public ClothesSetup GetSetupByType(ClothType clothType)
    {
        return clothesSetups.Find(i => i.clothType == clothType);
    }
}

[System.Serializable]
public class ClothesSetup
{
    public ClothType clothType;
    public Texture2D texture;
}