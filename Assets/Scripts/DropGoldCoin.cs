using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGoldCoin : MonoBehaviour
{
    public GameObject coin;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void deathDrop(){
        Debug.Log("gold dropped");
        Instantiate(coin,transform.position, Quaternion.identity);
    }
}
