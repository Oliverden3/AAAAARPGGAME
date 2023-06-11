using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "shopmenu", menuName = "Scriptable Objects/New Shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
   public string title;
   public string description;
   public int baseCost;
   public int attackValue;
   public int hpValue;

}
