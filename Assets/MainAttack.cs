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
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Input.mousePosition");
            location = playerObj.transform.position;
            GameObject go1;
            go1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go1.transform.position = location;
            go1.AddComponent<DestroyAfterTime>();
        }
    }
    }
