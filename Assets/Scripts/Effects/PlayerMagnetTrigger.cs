using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnetTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CollectableBase i = other.transform.GetComponent<CollectableBase>();
        if(i != null)
        {
            i.gameObject.AddComponent<Magnet>();
        }
    }
}
