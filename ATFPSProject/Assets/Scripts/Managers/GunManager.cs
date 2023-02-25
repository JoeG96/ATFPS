using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunManager : MonoBehaviour
{

    public enum gunSelecter
    {
        Pistol,
        Shotgun
    }
    public gunSelecter selectedGun;

    [SerializeField] GameObject shotgunUIObject;
    [SerializeField] GameObject pistolUIObject;

    
    
    [SerializeField] GameObject bulletHole;

    private Camera cam;

    [SerializeField] TextMeshProUGUI promptText;

    [Header("Shotgun Stats")]
    [SerializeField] float shotgunCurrentAmmo = 40;
    [SerializeField] float shotgunMagSize = 2;
    [SerializeField] float shotgunAmmoInMag = 2;
    [SerializeField] float shotgunTotalAmmoCap = 50;
    [SerializeField] float shotgunDamage = 50;
    [SerializeField] float shotgunShotsPerFire = 2;
    [SerializeField] float shotgunFireDelay = 0.2f;
    [SerializeField] float shotgunReloadTime = 1;

    [Header("Pistol Stats")]
    [SerializeField] float pistolCurrentAmmo = 100;
    [SerializeField] float pistolMagSize = 15;
    [SerializeField] float pistolAmmoInMag = 15;
    [SerializeField] float pistolTotalAmmoCap = 150;
    [SerializeField] float pistolDamage = 10;
    [SerializeField] float pistolShotsPerFire = 1;
    [SerializeField] float pistolFireDelay = 0f;
    [SerializeField] float pistolReloadTime = 2;

    private bool readyToShoot;


    [Header("UI Objects")]
    [SerializeField] TextMeshProUGUI totalShotgunAmmoText;
    [SerializeField] TextMeshProUGUI currentShotgunAmmoText;
    [SerializeField] TextMeshProUGUI totalPistolAmmoText;
    [SerializeField] TextMeshProUGUI currentPistolAmmoText;
    
    [SerializeField] TextMeshProUGUI ammoText;

    [Header("Animators")]
    [SerializeField] Animator shotgunAnimator;
    [SerializeField] Animator pistolAnimator;

    [Header("Audio")]
    [SerializeField] AudioClip shotgunShotSound;
    [SerializeField] AudioClip pistolShotSound;
    [SerializeField] AudioClip ammoPickupSound;
 
    void Awake()
    {
        cam = Camera.main;

        gunSelecter selectedGun = gunSelecter.Pistol;
        
        switch (selectedGun)
        {
            case gunSelecter.Pistol:
                {
                    totalPistolAmmoText.text = "/" + pistolTotalAmmoCap.ToString();
                }
                break;
            case gunSelecter.Shotgun:
                {
                    totalShotgunAmmoText.text = "/" + shotgunTotalAmmoCap.ToString();
                }
                break;
        }
        GetComponent<AudioSource>().Stop();
        readyToShoot = true;
    }

    private void Update()
    {
        switch (selectedGun)
        {
            case gunSelecter.Pistol:
                {
                    shotgunUIObject.SetActive(false);
                    pistolUIObject.SetActive(true);
                }
                break;
            case gunSelecter.Shotgun:
                {
                    shotgunUIObject.SetActive(true);
                    pistolUIObject.SetActive(false);
                }
                break;
        }
        UpdateAmmoUI();
    }

    private void UpdateAmmoUI()
    {
        switch (selectedGun)
        {
            case gunSelecter.Pistol:
                {
                    ammoText.text = pistolAmmoInMag.ToString();
                }
                break;
            case gunSelecter.Shotgun:
                {

                    ammoText.text = shotgunAmmoInMag.ToString();
                }
                break;
        }
        currentPistolAmmoText.text = pistolCurrentAmmo.ToString();
        currentShotgunAmmoText.text = shotgunCurrentAmmo.ToString();
    }

    public void ShootWeapon()
    {
        if (readyToShoot)
        {
            switch (selectedGun)
            {
                case gunSelecter.Pistol:
                    {
                        ShootPistol();
                    }
                    break;
                case gunSelecter.Shotgun:
                    {
                        ShootShotgun();
                    }
                    break;
            }
        } 
    }

    public void ShootShotgun()
    {

        if (shotgunAmmoInMag > 0 )
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Environment"))
                {
                    Instantiate(bulletHole, hit.point, transform.rotation);
                }

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    //Debug.Log("Enemy Hit");
                    //Debug.Log(hit.collider.gameObject.name);
                    hit.collider.gameObject.GetComponentInParent<Enemy>().TakeDamage(shotgunDamage);
                }

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("DamageObject"))
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    hit.collider.gameObject.GetComponent<BarrelExplosion>().TakeDamage(shotgunDamage);
                }
            }
            shotgunAmmoInMag -= shotgunShotsPerFire;
            shotgunAnimator.SetTrigger("Shoot");
            GetComponent<AudioSource>().PlayOneShot(shotgunShotSound, 0.5f);

        }


        if (shotgunAmmoInMag <= 0)
        {
            shotgunAmmoInMag = 0;
            StartCoroutine("Reload", shotgunReloadTime);
            if (shotgunCurrentAmmo >= shotgunMagSize)
            {
                shotgunCurrentAmmo -= shotgunMagSize;
                shotgunAmmoInMag += shotgunMagSize;
            }
            else
            {
                shotgunAmmoInMag += shotgunCurrentAmmo;
                shotgunCurrentAmmo -= shotgunCurrentAmmo;
            }
            
        }
    }

    public void ShootPistol()
    {
        if (pistolAmmoInMag > 0)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Environment"))
                {
                    Instantiate(bulletHole, hit.point, transform.rotation);
                }

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    //Debug.Log("Enemy Hit");
                    //Debug.Log(hit.collider.gameObject.name);
                    hit.collider.gameObject.GetComponentInParent<Enemy>().TakeDamage(pistolDamage);
                }

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("DamageObject"))
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    hit.collider.gameObject.GetComponent<BarrelExplosion>().TakeDamage(pistolDamage);
                }
            }
            pistolAmmoInMag -= pistolShotsPerFire;
            pistolAnimator.SetTrigger("Shoot");
            GetComponent<AudioSource>().PlayOneShot(pistolShotSound, 0.5f);
        }

        if (pistolAmmoInMag <= 0)
        {
            pistolAmmoInMag = 0;
            StartCoroutine("Reload", pistolReloadTime);
            if (pistolCurrentAmmo >= pistolMagSize)
            {
                pistolCurrentAmmo -= pistolMagSize;
                pistolAmmoInMag += pistolMagSize;
            }
            else
            {
                pistolAmmoInMag += pistolCurrentAmmo;
                pistolCurrentAmmo -= pistolCurrentAmmo;
            }
        }
    }

    IEnumerator Reload(float reloadTime)
    {
        readyToShoot = false;
        yield return new WaitForSeconds(reloadTime);
        readyToShoot = true;
    }

    IEnumerator ShotDelay(float delayTime)
    {
        readyToShoot = false;
        yield return new WaitForSeconds(delayTime);
        readyToShoot = true;
    }

    public void SetWeaponToPistol()
    {
        selectedGun = gunSelecter.Pistol;
    }

    public void SetWeaponToShotgun()
    {
        selectedGun = gunSelecter.Shotgun;
    }

    public void RestorePistolAmmo(float amount, GameObject gameObject)
    {

        float remainingAmmo = pistolTotalAmmoCap - pistolCurrentAmmo;

        if (pistolCurrentAmmo <= pistolTotalAmmoCap)
        {
            if (remainingAmmo <= amount)
            {
                pistolCurrentAmmo += remainingAmmo;
            }
            else
            {
                pistolCurrentAmmo += amount;
            }
            GetComponent<AudioSource>().PlayOneShot(ammoPickupSound);
            Destroy(gameObject);
        }
        else
        {
            return;
        }

    }
    
    public void RestoreShotgunAmmo(float amount, GameObject gameObject)
    {
        float remainingAmmo = shotgunTotalAmmoCap - shotgunCurrentAmmo;

        if (shotgunCurrentAmmo <= shotgunTotalAmmoCap)
        { 
            if (remainingAmmo <= amount)
            {
                shotgunCurrentAmmo += remainingAmmo;
            }
            else
            {
                shotgunCurrentAmmo += amount;
            }
            GetComponent<AudioSource>().PlayOneShot(ammoPickupSound);
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
