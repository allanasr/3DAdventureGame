using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    public int key = 1;
    private string checkpointKey = "CheckpointKey";
    private bool checkpointActivated = false;

    private void Start()
    {
        TurnOff();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!checkpointActivated && other.transform.tag == "Player")
        {
            CheckCheckpoint();
        }
    }

    private void CheckCheckpoint()
    {
        SaveCheckpoint();
        TurnOn();
    }

    [NaughtyAttributes.Button]
    private void TurnOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    }
    [NaughtyAttributes.Button]
    private void TurnOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }

    private void SaveCheckpoint()
    {
        CheckpointManager.Instance.SaveCheckPoint(key);
        SaveManager.Instance.SaveItens();

        checkpointActivated = true;
    }
}
