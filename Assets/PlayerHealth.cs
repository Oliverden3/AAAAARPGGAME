using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    [SerializeField] private Canvas HealthBarCanvas;
    private HealthbarFill healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = HealthBarCanvas.GetComponent<HealthbarFill>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BeginningHealth(int playerHealth){
        maxHealth = playerHealth;
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage){
        currentHealth =  currentHealth-damage;
    healthBar.updateHealthBar(currentHealth,maxHealth);
    Debug.Log("you took damage "+ currentHealth);
    }
}
