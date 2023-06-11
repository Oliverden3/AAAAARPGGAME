using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statManager : MonoBehaviour
{
    GameObject playerObj;
    public int maxHealth;
    public int damage;
    public float speed;
    public static int currentCoins = 200;
    // Start is called before the first frame update
    void Start()
    {
        SetMainCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetMainCharacter(){
        playerObj = GameObject.Find("Player");
        PlayerMovement movement = playerObj.GetComponent<PlayerMovement>();
        Transform mainAttack = playerObj.transform.GetChild(0); //Assuming MainAttack is the first child object
        movement.speed = speed;
        DamageField df = mainAttack.GetComponent<DamageField>();
        df.changeDamage(damage);
        PlayerHealth playerHealth = playerObj.GetComponent<PlayerHealth>();
        playerHealth.BeginningHealth(maxHealth);
    }
    public void addCoin(int coinValue){
        currentCoins = currentCoins+coinValue;
    }
    public int GetCoins(){
        return currentCoins;
    }
    public void addDamage(int damageValue){
    damage = damage+damageValue;
    SetMainCharacter();
    }
    public int getDamage(){
        return damage;
    }
    public void addHealth(int healthValue){
    maxHealth = maxHealth+healthValue;
    SetMainCharacter();
    }
    public int getHealth(){
        return maxHealth;
    }
    public void addSpeed(float speedValue){
    speed = speed+speedValue;
    SetMainCharacter();
    }
    public float getSpeed(){
        return speed;
    }
}
