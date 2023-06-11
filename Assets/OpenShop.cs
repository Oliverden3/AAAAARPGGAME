using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject Canvas; 
    public GameObject AttackToDisable; 
    // Start is called before the first frame update
    void Start()
    {
       Canvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Canvas.SetActive(true);
        AttackToDisable.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D other) {
        Canvas.SetActive(false);
        AttackToDisable.SetActive(true);
    }
}
