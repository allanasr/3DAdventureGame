using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{

    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }
}
