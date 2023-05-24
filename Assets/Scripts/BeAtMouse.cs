using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAtMouse : MonoBehaviour
{
    private bool CheckifDead;
    private GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        playerObj= GameObject.Find("Player");
    }

    // Update is called once per frame
void Update()
{
    CheckifDead = playerObj.GetComponent<PlayerHealth>().isDead;
    if(CheckifDead == false){
    Vector3 mousePos = Input.mousePosition;
    mousePos.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    Vector3 location = new Vector3(worldPosition.x, worldPosition.y, 0f);
    
    transform.position = location;
    }
}

}
