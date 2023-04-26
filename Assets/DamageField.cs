using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageField : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        Debug.Log("I hit something");
            if (other.gameObject.tag == "Enemy"){
                Debug.Log("I HIT AN ENEMY");
               Health monsterHP = other.gameObject.GetComponent<Health>();
               monsterHP.TakeDamage(damage);
            }
    }
    public void changeDamage(int newDamage){
        damage = newDamage;
    }
}
