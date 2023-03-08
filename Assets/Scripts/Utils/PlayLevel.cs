using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayLevel : MonoBehaviour
{
    public TextMeshProUGUI uiTextName;
    private void Start()
    {
        if(uiTextName != null) SaveManager.Instance.fileLoaded += OnLoad;
    }

    public void OnLoad(SaveSetup setup)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
            uiTextName.text = "Play Level " + (setup.lastLevel + 1);
    }

    private void OnDestroy()
    {
        SaveManager.Instance.fileLoaded -= OnLoad;
    }
}
