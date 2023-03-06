using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float dist = .2f;
    public float speed = 5f;
    void Update()
    {
        if(Vector3.Distance(transform.position, Player.Instance.transform.position) > dist)
        {
            speed++;
            transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, Time.deltaTime * speed);
        }
    }
}
