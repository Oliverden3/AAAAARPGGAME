using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSound : MonoBehaviour
{
    public AudioClip soundEffect;
    bool isAttacking;


    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;

    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0) && isAttacking == false)
    { 
        PlaySound();
    }
    }
    private void PlaySound(){
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
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
