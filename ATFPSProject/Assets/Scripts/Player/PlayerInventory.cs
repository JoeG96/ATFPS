using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    public bool hasRedKey, hasBlueKey, hasGreenKey;
    [SerializeField] RawImage redKeyIndicator, blueKeyIndicator, greenKeyIndicator;

    public void CheckKeys()
    {
        if (hasRedKey)
        {
            redKeyIndicator.color = new Color(redKeyIndicator.color.r, redKeyIndicator.color.g, redKeyIndicator.color.b, 255);
        }

        if (hasGreenKey)
        {
            greenKeyIndicator.color = new Color(greenKeyIndicator.color.r, greenKeyIndicator.color.g, greenKeyIndicator.color.b, 255);
        }

        if (hasBlueKey)
        {
            blueKeyIndicator.color = new Color(blueKeyIndicator.color.r, blueKeyIndicator.color.g, blueKeyIndicator.color.b, 255);
        }
    }
}
