using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : EnemyBase
{
    [Header("Waypoints")]
    public GameObject[] waypoints;
    public float minDistance = 1f;
    public float speed = 1f;

    private int index = 0;
    protected override void Update()
    {
        base.Update();

        if(Vector3.Distance(transform.position, waypoints[index].transform.position) < minDistance)
        {
            index++;
            if(index >= waypoints.Length)
            {
                index = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, Time.deltaTime * speed);
        transform.LookAt(waypoints[index].transform.position);

    }
}
