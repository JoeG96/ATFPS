using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float health;
    public float maxHealth = 100f;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] Image damageOverlay;
    [SerializeField] float duration;
    [SerializeField] float fadeSpeed;
    private float _durationTimer;

    void Start()
    {
        health = maxHealth;
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 0);
    }


    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
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
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 1);
        _durationTimer = 0;
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
    }
}
