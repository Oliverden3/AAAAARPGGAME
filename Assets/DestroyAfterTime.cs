using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitASec());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitASec(){
    yield return new WaitForSeconds(1);
    Destroy(gameObject);
    }
}
