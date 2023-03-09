using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionLifePack : MonoBehaviour
{
    public SFXType SFXType;
    public SOInt sOInt;

    private void Start()
    {
        sOInt = CollectableManager.Instance.GetByType(ItemType.LIFE_PACK).sOInt;

    }

    private void RecoverLife()
    {
        if(sOInt.value > 0)
        {
            CollectableManager.Instance.RemoveByType(ItemType.LIFE_PACK);
            Player.Instance.healthBase.ResetLife();
        }
    }

    private void Play()
    {
        SFXPool.Instance.Play(SFXType);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            RecoverLife();
            Play();
        }
    }
}
