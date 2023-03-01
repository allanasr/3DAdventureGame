using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GunShootLimit : GunBase
{
    public List<UIGunUpdater> uIGunUpdaters;

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
            uIGunUpdaters.ForEach(i => i.UpdateValue(time/timeToReload));
            yield return new WaitForEndOfFrame();
        }

        currentShots = 0;
        reloading = false;
    }

    private void UpdateUI()
    {
        uIGunUpdaters.ForEach(i => i.UpdateValue(maxShots, currentShots));
    }

    private void GetAllUIs()
    {
        uIGunUpdaters = GameObject.FindObjectsOfType<UIGunUpdater>().ToList();
    }
}
