using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public GameObject playerObj;
    public Sprite hero1;
    public Sprite hero2;
    public Sprite hero3;
    public Sprite hero4;

    private SpriteRenderer spriteRenderer;
    private Vector2 oldPosition;
    private Vector2 newPosition;

    void Start()
    {
        oldPosition = playerObj.transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        newPosition = playerObj.transform.position;
        if(newPosition != oldPosition){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

         if (newPosition.x<oldPosition.x) 
         {
             spriteRenderer.flipX = false;
             spriteRenderer.sprite = hero3;
         } 
         else if (newPosition.x>oldPosition.x) 
         {
             spriteRenderer.flipX = true;
             spriteRenderer.sprite = hero3;
         } 
         else if (newPosition.y>oldPosition.y) 
         {
             spriteRenderer.sprite = hero2;
          } 
           else if (newPosition.y<oldPosition.y) 
          {   
             spriteRenderer.sprite = hero4;
            } 
        }
        else{
            spriteRenderer.sprite = hero1;
        }
        oldPosition = newPosition;
    }
}
