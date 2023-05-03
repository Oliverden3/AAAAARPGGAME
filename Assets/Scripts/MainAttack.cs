using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAttack : MonoBehaviour
{
  public GameObject attackCone;
  SpriteRenderer spriteR;
  PolygonCollider2D m_Collider;
  bool isAttacking;

    // Start is called before the first frame update
  void Start()
    {
      spriteR = attackCone.GetComponent<SpriteRenderer>();
      m_Collider = attackCone.GetComponent<PolygonCollider2D>();
      spriteR.enabled = false;
      m_Collider.enabled = false;
      isAttacking = false;
    }

    // Update is called once per frame
  void Update()
    {
      if (Input.GetMouseButtonDown(0) && isAttacking == false){
        spriteR.enabled = true;
        m_Collider.enabled = true;
        isAttacking = true;
        StartCoroutine(WaitASec());
      }
    }
  IEnumerator WaitASec(){
    yield return new WaitForSeconds(0.5f);
    spriteR.enabled = false;
    m_Collider.enabled = false;
    isAttacking = false;
    }
}
