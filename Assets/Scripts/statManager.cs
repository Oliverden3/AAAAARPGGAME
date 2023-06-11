using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statManager : MonoBehaviour
{
    GameObject playerObj;
    public static int maxHealth;
    public static int damage;
    public float speed;
    public static int currentCoins = 200;
    // Start is called before the first frame update
    void Start()
    {
        if(damage == 0){
            damage = 10;
        }
        if(maxHealth == 0){
            maxHealth = 10;
        }
        Debug.Log(damage);
        Debug.Log(maxHealth);
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
    Debug.Log(damage);
    }
    public int getDamage(){
        return damage;
    }
    public void addHealth(int healthValue){
    maxHealth = maxHealth+healthValue;
    SetMainCharacter();
    Debug.Log(maxHealth);

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
