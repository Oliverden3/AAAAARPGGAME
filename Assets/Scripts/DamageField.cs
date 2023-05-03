using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageField : MonoBehaviour
{
    SpriteRenderer spriteR;
    PolygonCollider2D m_Collider;
    bool isAttacking;
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
      spriteR = GetComponent<SpriteRenderer>();
      m_Collider = GetComponent<PolygonCollider2D>();
      spriteR.enabled = false;
      m_Collider.enabled = false;
      isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isAttacking == false){
        Attack();
      }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("I hit something");
            if (other.gameObject.tag == "Enemy"){
                Debug.Log("I HIT AN ENEMY");
               Health monsterHP = other.gameObject.GetComponent<Health>();
               monsterHP.TakeDamage(damage);
               Debug.Log(monsterHP.SendCurrentHealth());
            }
    }
    public void changeDamage(int newDamage){
        damage = newDamage;
    }
    private void Attack(){
      spriteR.enabled = true;
        m_Collider.enabled = true;
        isAttacking = true;
        StartCoroutine(WaitASec());
    }
    IEnumerator WaitASec(){
    yield return new WaitForSeconds(0.5f);
    spriteR.enabled = false;
    m_Collider.enabled = false;
    StartCoroutine(AttackCooldown());
    }
    IEnumerator AttackCooldown(){
      yield return new WaitForSeconds(2.0f);
      isAttacking = false;
    }
}
