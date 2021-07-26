using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClothShopPanel : MonoBehaviour, IDropHandler
{
    private ClothShop clothShop;

    private void Start()
    {
        clothShop = transform.root.gameObject.GetComponent<ClothShop>();   
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag)
        {
            if (!clothShop || !clothShop.playerMoney) return;

            // Get item data
            ClothItemSO clothItem = (ClothItemSO)eventData.pointerDrag.GetComponent<ItemInventory>().itemData;
            eventData.pointerDrag.GetComponent<ItemInventory>().droppedOnSlot = true;
            Destroy(eventData.pointerDrag);

            clothShop.playerMoney.ReceiveMoney(clothItem.SellMoney);
        }
    }
}
