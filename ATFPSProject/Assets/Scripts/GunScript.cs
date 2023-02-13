using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunScript : MonoBehaviour
{

    [Header("Gun Stats")]
    [SerializeField] float totalAmmoCap;
    [SerializeField] float magSize;
    [SerializeField] float ammoInMag;
    [SerializeField] float currentAmmo;

    [SerializeField] TextMeshProUGUI totalAmmoText;
    [SerializeField] TextMeshProUGUI currentAmmoText;
    [SerializeField] TextMeshProUGUI ammoText;

    public enum GunType
    {
        Pistol,
        Shotgun,
        RocketLauncher
    };
    public GunType gunType;


    void Start()
    {
        totalAmmoText.text = "/" + totalAmmoCap.ToString();


    }

    void Update()
    {


        currentAmmoText.text = currentAmmo.ToString();
        ammoText.text = ammoInMag.ToString();
    }

}
