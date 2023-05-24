using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool isDead;
    private int maxHealth;
    private int currentHealth;
    [SerializeField] private Canvas HealthBarCanvas;
    private HealthbarFill healthBar;
    private GameObject deathCanvas;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        healthBar = HealthBarCanvas.GetComponent<HealthbarFill>();
        deathCanvas = GameObject.Find("DeathCanvas");
        deathCanvas.SetActive(false);
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
    if(currentHealth<=0){PlayerDeath();}
    }
    public void PlayerDeath(){
        Time.timeScale = 0;
        isDead = true;
        deathCanvas.SetActive(true);
    }
}
