using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        
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
    Debug.Log("you took damage"+ currentHealth);
    }
}
