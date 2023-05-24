using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadSceneAdjustable : MonoBehaviour
{
    public int designatedScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectLevel(){
        Time.timeScale = 1;
        SceneManager.LoadScene(designatedScene);
    }
}
