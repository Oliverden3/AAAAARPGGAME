using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCoins : MonoBehaviour
{
    private GameObject gameManager;
    private statManager theStatManager;
    private int coins;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        theStatManager = gameManager.GetComponent<statManager>();
    }

    // Update is called once per frame
    void Update()
    {
        coins = theStatManager.GetCoins();
        string textFile = "You have " + coins + " gold";
        text.text = textFile;
    }
}
