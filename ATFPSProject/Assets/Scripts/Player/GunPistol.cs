using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunPistol : MonoBehaviour
{

    [SerializeField] AudioClip pistolShotSound;
    [SerializeField] GameObject bulletHole;

    private Camera cam;
    
    [Header("Pistol Stats")]
    [SerializeField] float currentAmmo = 100;
    [SerializeField] float magSize = 15;
    [SerializeField] float ammoInMag = 15;
    [SerializeField] float totalAmmoCap = 150;
    [SerializeField] float pistolDamage = 10;

    [SerializeField] TextMeshProUGUI totalAmmoText;
    [SerializeField] TextMeshProUGUI currentAmmoText;
    [SerializeField] TextMeshProUGUI ammoText;

    [SerializeField] Animator PistolAnimator;

    void Awake()
    {
        cam = Camera.main;
        totalAmmoText.text = "/" + totalAmmoCap.ToString();
        GetComponent<AudioSource>().Stop();
    }

    private void Update()
    {
        UpdateAmmoUI();
    }

    private void UpdateAmmoUI()
    {
        currentAmmoText.text = currentAmmo.ToString();
        ammoText.text = ammoInMag.ToString();
    }

    public void Shoot()
    {

        // If has ammo and not shooting already
        // do the play shoot animation

        if (ammoInMag > 0)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Environment"))
                {
                    Instantiate(bulletHole, hit.point, transform.rotation);
                }
                
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    Debug.Log("Enemy Hit");
                    Debug.Log(hit.collider.gameObject.name);
                    hit.collider.gameObject.GetComponentInParent<Enemy>().TakeDamage(pistolDamage);
                }
                
            }
            ammoInMag--;
            PistolAnimator.SetTrigger("Shoot");
            GetComponent<AudioSource>().PlayOneShot(pistolShotSound, 0.5f);

        }

        if (ammoInMag <= 0)
        {
            //Reload
            currentAmmo -= magSize;
            ammoInMag += magSize;

        }
       

    }

    public void RestoreAmmo(float amount, GameObject gameObject)
    {
        currentAmmo += amount;
        Destroy(gameObject);
    }
}
