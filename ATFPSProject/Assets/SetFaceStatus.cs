using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFaceStatus : MonoBehaviour
{

    [SerializeField] Sprite fullHealthSprite;
    [SerializeField] Sprite highHealthSprite;
    [SerializeField] Sprite medHealthSprite;
    [SerializeField] Sprite lowHealthSprite;
    [SerializeField] Sprite noHealthSprite;

    [SerializeField] Image faceImage;
    [SerializeField] PlayerHealth playerHealth;
    

    void Start()
    {
        faceImage.sprite = fullHealthSprite;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealth.GetHealth() >= 75)
        {
            faceImage.sprite = fullHealthSprite;
        }

        if (playerHealth.GetHealth() < 75 & playerHealth.GetHealth() >= 50)
        {
            faceImage.sprite = highHealthSprite;
        }
        
        if (playerHealth.GetHealth() < 50 & playerHealth.GetHealth() >= 25)
        {
            faceImage.sprite = medHealthSprite;
        }
        
        if (playerHealth.GetHealth() < 25 & playerHealth.GetHealth() > 0)
        {
            faceImage.sprite = lowHealthSprite;
        }
        
        if (playerHealth.GetHealth() <= 0)
        {
            faceImage.sprite = noHealthSprite;
        }

    }

    public void SetFaceImage(Sprite sprite)
    {
        faceImage.sprite = sprite;
    }
}
