using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GunShootLimit : GunBase
{
    public UIFillUpdater uIGunUpdater;

    public int maxShots = 5;
    public float timeToReload = 1f;

    private int currentShots;

    private bool reloading = false;

    private void Awake()
    {
        GetAllUIs();
    }
    protected override IEnumerator ShootCoroutine()
    {
        if (reloading) yield break;

        while (true)
        {
            if (currentShots <= maxShots)
            {
                Shoot();
                currentShots++;
                CheckReload();
                UpdateUI();
                yield return new WaitForSeconds(timeBetweenShots);
            }
        }
    }

    private void CheckReload()
    {
        if (currentShots >= maxShots)
        {
            StopShoot();
            StartReload();

        }

    }

    private void StartReload()
    {
        reloading = true;
        StartCoroutine(ReloadCoroutine());
    }

    IEnumerator ReloadCoroutine()
    {
        float time = 0;

        while (time < timeToReload)
        {
            time += Time.deltaTime;
            uIGunUpdater.UpdateValue(time/timeToReload);
            yield return new WaitForEndOfFrame();
        }

        currentShots = 0;
        reloading = false;
    }

    private void UpdateUI()
    {
        uIGunUpdater. UpdateValue(maxShots, currentShots);
    }

    private void GetAllUIs()
    {
        uIGunUpdater = GameObject.FindGameObjectWithTag("GunUI").GetComponent<UIFillUpdater>();
    }
}
