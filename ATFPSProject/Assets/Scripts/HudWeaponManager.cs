using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudWeaponManager : MonoBehaviour
{

    [SerializeField] Sprite pistolSprite;
    [SerializeField] Sprite shotgunSprite;
    [SerializeField] Sprite rocketLauncherSprite;
    [SerializeField] Image UIImage;
    [SerializeField] Image UIWeaponSelect1;
    [SerializeField] Image UIWeaponSelect2;
    [SerializeField] Image UIWeaponSelect3;

    void Start()
    {
        UIImage.sprite = pistolSprite;
    }

    public void SetUIWeapon(string weapon)
    {
        if (weapon == "Shotgun")
        {
            UIImage.sprite = shotgunSprite;
            UIWeaponSelect1.color = new Color(255, 255, 255, 0.5f);
            UIWeaponSelect2.color = new Color(255, 255, 255, 1f);
            UIWeaponSelect3.color = new Color(255, 255, 255, 0.5f);

        }
        
        if (weapon == "Pistol")
        {
            UIImage.sprite = pistolSprite;
            UIWeaponSelect1.color = new Color(255, 255, 255, 1f);
            UIWeaponSelect2.color = new Color(255, 255, 255, 0.5f);
            UIWeaponSelect3.color = new Color(255, 255, 255, 0.5f);

        }
        
        if (weapon == "RocketLauncher")
        {
            UIImage.sprite = rocketLauncherSprite;
            UIWeaponSelect1.color = new Color(255, 255, 255, 0.5f);
            UIWeaponSelect2.color = new Color(255, 255, 255, 0.5f);
            UIWeaponSelect3.color = new Color(255, 255, 255, 1f);
        }
    }
}
