using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float health;
    public float maxHealth = 100f;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] Image damageOverlay;
    [SerializeField] float duration;
    [SerializeField] float fadeSpeed;
    private float _durationTimer;

    [SerializeField] float armor;
    [SerializeField] float maxArmor;
    [SerializeField] TextMeshProUGUI armorText;

    [SerializeField] AudioClip healthPickupSound;
    [SerializeField] AudioClip armorPickupSound;
    [SerializeField] AudioClip playerDamageSound;


    void Start()
    {
        health = maxHealth;
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 0);
    }


    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        armor = Mathf.Clamp(armor, 0, maxArmor);

        UpdateHealth();

        

        if (damageOverlay.color.a > 0)
        {
            if (health < 30)
            {
                return;
            }
            _durationTimer += Time.deltaTime;
            if (_durationTimer > duration)
            {
                float tempAlpha = damageOverlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, tempAlpha);
            }
        }

    }

    public void UpdateHealth()
    {
        healthText.text = health.ToString();
        armorText.text = armor.ToString();
    }

    public void TakeDamage(float damage)
    {

        if (armor > 0)
        {
            if (armor >= damage)
            {
                armor -= damage;
            }
            else if (armor < damage)
            {
                float remainingDamage = damage - armor;
                armor = 0;
                health -= remainingDamage;
            }
        }
        else
        {
            health -= damage;
            
            damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 1);
            _durationTimer = 0;
        }

        if (health <= 0)
        {
            PlayerDied();
            
        }
        GetComponent<AudioSource>().PlayOneShot(playerDamageSound);


    }

    public void PlayerDied()
    {
        Debug.Log("Player Dead");

        var levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.GameOver();
        
    }

    public void RestoreHealth(float healAmount, GameObject pickup)
    {
        
        if (health < maxHealth)
        {
            health += healAmount;
            GetComponent<AudioSource>().PlayOneShot(healthPickupSound);
            Destroy(pickup);

        }

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void RestoreArmor(float armorAmount, GameObject pickup)
    {

        if (armor < maxArmor)
        {
            armor += armorAmount;
            GetComponent<AudioSource>().PlayOneShot(armorPickupSound);
            Destroy(pickup);
        }

        if (armor >= maxArmor)
        {
            armor = maxArmor;
        }
    }

    public float GetHealth()
    {
        return health;
    }
}
