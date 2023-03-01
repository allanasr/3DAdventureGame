using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{

    public List<GunBase> gunBases;

    public Transform gunPostion;

    private GunBase currentGun;

    private GunBase primaryGun;
    private GunBase secondaryGun;

    protected override void Init()
    {
        base.Init();

        CreateGun();

        inputs.Gameplays.Shoot.performed += ctx => Shoot();
        inputs.Gameplays.Shoot.canceled += ctx => CancelShoot();
        inputs.Gameplays.Gun1.performed += ctx => ChangeGuns();
        inputs.Gameplays.Gun2.performed += ctx => ChangeGuns();
    }

    private void ChangeGuns()
    {
        if(inputs.Gameplays.Gun1.IsPressed())
        {
            currentGun = primaryGun;
        }
        else if(inputs.Gameplays.Gun2.IsPressed())
        {
            currentGun = secondaryGun;
        }

        UpdateGunPositions();
    }
    private void CreateGun()
    {
        primaryGun = currentGun = Instantiate(gunBases[0], gunPostion);
        secondaryGun = Instantiate(gunBases[1], gunPostion);

        //secondaryGun.gameObject.SetActive(false);

        UpdateGunPositions();
    }
    private void Shoot()
    {
        currentGun.StartShoot();
    }
    private void CancelShoot()
    {
        currentGun.StopShoot(); 
    }

    private void UpdateGunPositions()
    {
        currentGun.transform.localPosition = currentGun.transform.localEulerAngles = Vector3.zero;

    }

}
