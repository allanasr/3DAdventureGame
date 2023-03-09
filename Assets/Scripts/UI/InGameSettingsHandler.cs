using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSettingsHandler : MonoBehaviour
{
    public GameObject settingScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            settingScreen.SetActive(true);
    }

    public void TurnOffScreen()
    {
        settingScreen.SetActive(false);
    }
}
