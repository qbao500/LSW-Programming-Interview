using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public struct clothStruct
{
    public clothTypeEnum clothType;
    public Image clothImage;
}

public class EquipmentPanel : MonoBehaviour, IDropHandler
{   
    private PlayerEquipment equipment;
    private PlayerInventory inventory;

    // Set this array in Inspector then apply to Dictionary below, since Dictionary cannot be edited in Inspector
    [SerializeField]
    private clothStruct[] cloths;

    // Equip images in Equipment Panel
    private Dictionary<clothTypeEnum, Image> clothImage;

    private void Start()
    {
        equipment = transform.root.gameObject.GetComponent<PlayerEquipment>();
        inventory = transform.root.gameObject.GetComponent<PlayerInventory>();

        // Implement dictionary
        clothImage = new Dictionary<clothTypeEnum, Image>();
        foreach (var cloth in cloths)
        {
            clothImage.Add(cloth.clothType, cloth.clothImage);
        }

        // Set sprites in Equipment Panel
        clothImage[clothTypeEnum.shirt].sprite = equipment.startShirt.clothSprite;
        clothImage[clothTypeEnum.pant].sprite = equipment.startPant.clothSprite;
        clothImage[clothTypeEnum.shoe].sprite = equipment.startShoe.clothSprite;
    }

    // Drop item to Equipment Panel
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag)
        {
            // Get item data and remove it from Inventory
            ClothItemSO clothItem = (ClothItemSO)eventData.pointerDrag.GetComponent<ItemInventory>().itemData;
            eventData.pointerDrag.GetComponent<ItemInventory>().droppedOnSlot = true;
            inventory.RemoveItem(clothItem);
            Destroy(eventData.pointerDrag);

            // Equip for player
            ClothItemSO oldCloth = ScriptableObject.CreateInstance<ClothItemSO>();
            equipment.EquipCloth(clothItem, ref oldCloth);

            // Update UI in Equipment
            clothImage[clothItem.clothType].sprite = clothItem.clothSprite;

            // Push back old cloth to Inventory, more like swapping
            inventory.AddItem(oldCloth);
        }
        
    }
}
