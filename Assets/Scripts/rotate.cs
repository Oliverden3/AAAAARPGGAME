using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public GameObject target;
   // public Camera sceneCamera;
    //Vector2 mousePos;
    //Vector2 playerPos;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 mousePosition = Input.mousePosition;
       // mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );
        //transform.up = direction;
        transform.LookAt(mousePosition);*/
        Vector3 look = transform.InverseTransformPoint(target.transform.position);
        float Angle = Mathf.Atan2(look.y,look.x) * Mathf.Rad2Deg;
        transform.Rotate(0,0,Angle);
    
        /*
         mousePos = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
         playerPos = new Vector2(transform.position.x,transform.position.y);
        Vector2 lookDirection = mousePos - playerPos;
        float theDirection = Mathf.Atan2(lookDirection.y,lookDirection.x)*Mathf.Rad2Deg - 90f;
        transform.Rotate(0, 0, theDirection, Space.World);
        */
    }
}
