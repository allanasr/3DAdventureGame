using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLayoutManager : MonoBehaviour
{
    public ItemLayout itemLayoutPrefab;

    public Transform container;

    public List<ItemLayout> itemLayouts;

    private void Start()
    {
        CreateItems();
    }
    private void CreateItems()
    {
        foreach(var setup in CollectableManager.Instance.itemSetup)
        {
            var item = Instantiate(itemLayoutPrefab, container);
            item.Load(setup);
            itemLayouts.Add(item);
        }
    }
}
