    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folowPlayer : MonoBehaviour
{
    private GameObject playerObj = null;
    Vector3 location;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       location = new Vector3 (playerObj.transform.position.x,playerObj.transform.position.y,-10.0f);
       transform.position = location;
    }
}
