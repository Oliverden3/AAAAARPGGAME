using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static statManager;


public class ShopManager : MonoBehaviour
{

   private GameObject gameManager =  GameObject.Find("GameManager");
   public int coins = gameManager.GetComponent<statManager>().getCoins;
   public TMP_Text coinUI;
   public ShopItemSO[] shopItemsSO;
   public ShopTemplate[] shopPanels;
   public GameObject[] shopPanelsSO;
   public Button[] myPurchaseBtns;


public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].baseCost) //if i have enough money.
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }
void Start()
{
    for (int i = 0; i < shopItemsSO.Length; i++)
    {
shopPanelsSO[i].SetActive(true);
    }
coinUI.text = "coins: " + coins.ToString();
LoadPanels();
CheckPurchaseable();
}

   public void AddCoins()
   {
    coins++;
    coinUI.text = "coins:  " + coins.ToString();
    CheckPurchaseable();
   }

   public void LoadPanels()
   {
    for (int i = 0; i < shopItemsSO.Length; i++)
    {
        shopPanels[i].titleTxt.text = shopItemsSO[i].title;
        shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
        shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
    }
   }

   public void PurchaseItem(int btnNo)
    {
        if (coins >= shopItemsSO[btnNo].baseCost)
        {
            coins = coins - shopItemsSO[btnNo].baseCost;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
            //Unlock Item.
        }
    }

 


}
