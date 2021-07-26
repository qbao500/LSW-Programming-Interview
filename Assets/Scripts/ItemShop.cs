using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemShop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Set when spawned
    [HideInInspector]
    public ItemSO itemData;
    [HideInInspector]
    public MasterShop shop;

    // Mouse hover
    public void OnPointerEnter(PointerEventData eventData)
    {
        shop.SetPrice(itemData.buyCost);
    }

    // Mouse unhover
    public void OnPointerExit(PointerEventData eventData)
    {
        shop.SetPrice(0);
    }

    // On click
    public void BuyCloth()
    {
        shop.BuyItem(itemData.buyCost, ref itemData);
    }
}
