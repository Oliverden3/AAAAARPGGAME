using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthbarFill : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;
    // Start is called before the first frame update

    public void updateHealthBar(int currentHealth, int maxHealth){
        float currentHealthFloat = (float)currentHealth;
        float maxHealthFloat = (float)maxHealth;
        _healthbarSprite.fillAmount = currentHealthFloat/maxHealthFloat;
        Debug.Log("Current maxhealth/currenthealth: "  + currentHealth/maxHealth);
        Debug.Log("Current Healthbarfill: "  +  _healthbarSprite.fillAmount);
    }
}
