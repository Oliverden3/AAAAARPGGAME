using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRotation : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.transform.rotation);
        transform.rotation = Player.transform.rotation;
    }
}
