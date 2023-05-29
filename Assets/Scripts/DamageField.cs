using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageField : MonoBehaviour
{

    SpriteRenderer spriteR;
    PolygonCollider2D m_Collider;
    public bool isAttacking;
    private int damage;
    GameObject stamina;
    public AudioClip soundEffect;
   
    // Start is called before the first frame update
    void Start()
    {
      spriteR = GetComponent<SpriteRenderer>();
      m_Collider = GetComponent<PolygonCollider2D>();
      spriteR.enabled = false;
      m_Collider.enabled = false;
      isAttacking = false;
      stamina = GameObject.Find("BarFill");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isAttacking == false){
        Attack();
        stamina.GetComponent<StaminaFill>().updateStamina();
      }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.tag == "Enemy"){
               Health monsterHP = other.gameObject.GetComponent<Health>();
               monsterHP.TakeDamage(damage);
              AudioSource.PlayClipAtPoint(soundEffect, transform.position);
               Debug.Log(monsterHP.SendCurrentHealth());
            }
    }
    public void changeDamage(int newDamage){
        damage = newDamage;
    }
    private void Attack(){
       // spriteR.enabled = true;
        m_Collider.enabled = true;
        isAttacking = true;
        StartCoroutine(WaitASec());
        StartCoroutine(AttackCooldown());
    }
    IEnumerator WaitASec(){
    yield return new WaitForSeconds(0.5f);
    
    m_Collider.enabled = false;
    spriteR.enabled = false;
    }
    IEnumerator AttackCooldown(){
      yield return new WaitForSeconds(2.0f);
      isAttacking = false;
    }
}
