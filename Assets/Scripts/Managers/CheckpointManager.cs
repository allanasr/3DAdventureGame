using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class CheckpointManager : Singleton<CheckpointManager>
{
    public int lastCheckPoint = 0;

    public List<Checkpoint> checkpoints;
    public void SaveCheckPoint(int i)
    {
        if(i > lastCheckPoint)
        {
            lastCheckPoint = i;
        }
    }

    public bool HasCheckpoint()
    {
        return lastCheckPoint > 0;
    }
    public Vector3 GetPositionFromLastCheckpoint()
    {
        var checkpoint = checkpoints.Find(i => i.key == lastCheckPoint);
        return checkpoint.transform.position;

    }
}
