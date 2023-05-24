using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnim : MonoBehaviour
{
    private Animator anim;

    bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0) && isAttacking == false){
        Attack();
        }
    }

    private void Attack(){
        anim.SetTrigger("SwordSwing");
        isAttacking = true;
        StartCoroutine(WaitASec());
}

IEnumerator WaitASec(){
    yield return new WaitForSeconds(0.5f);
    
    StartCoroutine(AttackCooldown());
    }
    IEnumerator AttackCooldown(){
      yield return new WaitForSeconds(2.0f);
      isAttacking = false;
    }
}
