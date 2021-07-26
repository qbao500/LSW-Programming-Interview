using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private Transform inventoryPanel;

    [SerializeField]
    private TextMeshProUGUI sellValueText;

    [SerializeField]
    private GameObject itemSlot;

    private List<ItemSO> Items;

    private void Start()
    {
        Items = new List<ItemSO>();
    }

    public void AddItem(ItemSO item)
    {
        // Add to inventory list
        Items.Add(item);

        // Spawn icon and set sprite and data
        ItemInventory itemInventory = Instantiate(itemSlot).GetComponent<ItemInventory>();
        itemInventory.transform.SetParent(inventoryPanel.transform, false);
        itemInventory.itemData = item;
        itemInventory.inventoryPanel = this.inventoryPanel;
        itemInventory.inventory = this;
        ClothItemSO clothItem = (ClothItemSO)item;
        itemInventory.gameObject.GetComponent<Image>().sprite = clothItem.clothSprite;
    }

    public void SetSellPriceText(float value)
    {
        sellValueText.text = value + "$";
    }
}
