using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAtMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(worldPosition);
        Vector3 location = new Vector3(worldPosition.x,worldPosition.y,0.0f);
        transform.position = location;
    }
}
