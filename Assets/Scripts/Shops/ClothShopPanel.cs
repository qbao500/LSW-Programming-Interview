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

    // Drop on Shop Panel to sell item
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag)
        {
            if (!clothShop || !clothShop.playerMoney) return;

            // Get item data and remove it from Inventory
            ClothItemSO clothItem = (ClothItemSO)eventData.pointerDrag.GetComponent<ItemInventory>().itemData;
            eventData.pointerDrag.GetComponent<ItemInventory>().droppedOnSlot = true;
            clothShop.playerMoney.Inventory.RemoveItem(clothItem);
            Destroy(eventData.pointerDrag);

            clothShop.playerMoney.ReceiveMoney(clothItem.SellMoney);
        }
    }
}
