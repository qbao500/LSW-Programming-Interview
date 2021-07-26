using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ItemSO : ScriptableObject
{
    public string itemName = "Item Name";
    // Buy cost, default is 1 so at least it has a price when forget to set it
    public float buyCost = 1;         
    // Sell rate, for now it's 50% of buyCost
    public float sellRate = 50;

    // TODO Add more properties

    public float SellMoney => buyCost - (buyCost * (sellRate / 100));
}
