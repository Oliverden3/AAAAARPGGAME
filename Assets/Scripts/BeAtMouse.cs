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
    Vector3 mousePos = Input.mousePosition;
    mousePos.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    Vector3 location = new Vector3(worldPosition.x, worldPosition.y, 0f);
    
    transform.position = location;
    Debug.Log("Mouse true position: " + mousePos);
    Debug.Log("orb position: " + location);
}

}
