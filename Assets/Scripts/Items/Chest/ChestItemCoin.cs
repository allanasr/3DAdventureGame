using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ChestItemCoin : ChestItemBase
{

    public int coinNumber = 5;
    public GameObject coinObject;
    public Vector2 randomRange = new Vector2(-2,2);

    public float animationDuration = .5f;
    private List<GameObject> itens = new List<GameObject>();
    public override void Collect()
    {
        base.Collect();
        foreach(var i in itens)
        {
            i.transform.DOMoveY(2f, animationDuration).SetRelative();
            i.transform.DOScale(0, animationDuration / 2).SetDelay(animationDuration/2) ;
            CollectableManager.Instance.AddByType(ItemType.COIN);
            i.SetActive(false);
        }
    }

    public override void ShowItem()
    {
        base.ShowItem();
        CreateItems();
    }

    private void CreateItems()
    {
        for(int i =0; i < coinNumber; i++)
        {
            var item = Instantiate(coinObject);
            item.transform.position = transform.position + Vector3.forward * Random.Range(randomRange.x, randomRange.y) + Vector3.right * Random.Range(randomRange.x,randomRange.y);
            item.transform.DOScale(0, 2f).SetEase(Ease.OutBack).From();
            itens.Add(item);
        }
    }
}
