using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAttack : MonoBehaviour
{
    private GameObject playerObj = null;
    Vector2 location;
    // Start is called before the first frame update
    void Start()
    {
      playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetMouseButtonDown(0)){
            Debug.Log("Input.mousePosition");
            location = playerObj.transform.position;
            GameObject go1;
            go1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go1.transform.position = location;
            go1.AddComponent<DestroyAfterTime>();
            go1.transform.rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - go1.transform.position);
        }
        */
         if (Input.GetMouseButtonDown(0))
        {
            // get mouse position
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // create triangle
        GameObject triangle = Instantiate(trianglePrefab, transform.position, Quaternion.identity);


            // calculate angle between triangle and mouse position
            Vector2 direction = mousePosition - (Vector2)triangle.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // rotate triangle to face mouse position
            triangle.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    }
