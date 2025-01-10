using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData gundata;
    [SerializeField] private Transform muzzle;

    float timeSinceFire;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
    }

    public void StartReload()
    {
        if (!gundata.reloading)
        {
            StartCoroutine(Reload());

        }
    }

    private IEnumerator Reload()
    {
        gundata.reloading = true;

        yield return new WaitForSeconds(gundata.reloadTime);

        gundata.currentAmmo = gundata.magSize;

        gundata.reloading = false;
    }

    private bool CanShoot() => !gundata.reloading && timeSinceFire > 1f / (gundata.fireRate / 60f);

    public void Shoot()
    {
        if (gundata.currentAmmo > 0)
        {
            if (Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hitInfo, gundata.maxDistance))
            {
                IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                damageable?.Damage(gundata.damage);
            }
            gundata.currentAmmo--;
            timeSinceFire = 0;
            OnGunFire();
        }
    }

    private void Update()
    {
        timeSinceFire += Time.deltaTime;

        Debug.DrawRay(muzzle.position, muzzle.forward);
    }
    private void OnGunFire()
    {

    }
}
