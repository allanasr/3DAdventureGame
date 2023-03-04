using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    
    public float timeBetweenShots = .3f;
    public float speed = 50f;

    private Coroutine currentCorroutine;


    protected virtual IEnumerator ShootCoroutine()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    protected virtual void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
        projectile.speed = speed;

        ShakeCamera.Instance.Shake();
    }

    public void StartShoot()
    {
        currentCorroutine = StartCoroutine(ShootCoroutine());
    }

    public void StopShoot()
    {
        if (currentCorroutine != null)
            StopCoroutine(currentCorroutine);
    }
}
