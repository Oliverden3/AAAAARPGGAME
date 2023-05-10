using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthbarFill : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;
    // Start is called before the first frame update

    public void updateHealthBar(int currentHealth, int maxHealth){
        _healthbarSprite.fillAmount = currentHealth/maxHealth;
    }
}
