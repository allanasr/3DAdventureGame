using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using TMPro;

public enum ItemType
{
    COIN,
    LIFE_PACK
}
public class CollectableManager : Singleton<CollectableManager>
{

    public List<ItemSetup> itemSetup;
    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        foreach(var i in itemSetup)
        {
            i.sOInt.value = 0;
        }
    }

    public void AddByType(ItemType itemType, int amount = 1)
    {
        if (amount < 0) return;
        itemSetup.Find(i => i.itemType == itemType).sOInt.value += amount;
    }
    public ItemSetup GetByType(ItemType itemType)
    {
        return itemSetup.Find(i => i.itemType == itemType);
    }
     public void RemoveByType(ItemType itemType, int amount = 1)
    {
        var item = itemSetup.Find(i => i.itemType == itemType);
        item.sOInt.value -= amount;
        if (item.sOInt.value < 0) item.sOInt.value = 0;
    }

}

[System.Serializable]
public class ItemSetup
{
    public ItemType itemType;
    public SOInt sOInt;
    public Sprite icon;
}