using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statManager : MonoBehaviour
{
    GameObject playerObj;
    public int maxHealth;
    public int damage;
    public float speed;
    public int currentCoins;
    // Start is called before the first frame update
    void Start()
    {
        setMainCharacter();
        currentCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setMainCharacter(){
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
        Debug.Log(currentCoins);
    }
    public int getCoins(){
        return currentCoins;
    }
}
