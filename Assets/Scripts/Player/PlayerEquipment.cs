using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    // Equip sprites
    private SpriteRenderer shirtSprite;
    private SpriteRenderer pantSprite;
    private SpriteRenderer leftShoeSprite;
    private SpriteRenderer rightShoeSprite;

    // Equip objects
    [SerializeField]
    private GameObject shirtObject;
    [SerializeField]
    private GameObject pantObject;
    [SerializeField]
    private GameObject leftShoeObject;
    [SerializeField]
    private GameObject rightShoeObject;

    // Starting clothes
    public ClothItemSO startShirt;
    public ClothItemSO startPant;
    public ClothItemSO startShoe;

    // Current equipments
    private Dictionary<clothTypeEnum, ClothItemSO> equippingClothes;

    private void Start()
    {
        // Initial equipment
        equippingClothes = new Dictionary<clothTypeEnum, ClothItemSO>();
        equippingClothes.Add(clothTypeEnum.shirt, startShirt);
        equippingClothes.Add(clothTypeEnum.pant, startPant);
        equippingClothes.Add(clothTypeEnum.shoe, startShoe);

        // Get sprite components
        shirtSprite = shirtObject.GetComponent<SpriteRenderer>();
        pantSprite = pantObject.GetComponent<SpriteRenderer>();
        leftShoeSprite = leftShoeObject.GetComponent<SpriteRenderer>();
        rightShoeSprite = rightShoeObject.GetComponent<SpriteRenderer>();

        // Set sprite for starter cloths of Player
        shirtSprite.sprite = startShirt.clothSprite;
        pantSprite.sprite = startPant.clothSprite;
        leftShoeSprite.sprite = startShoe.clothSprite;
        rightShoeSprite.sprite = startShoe.clothSprite;

    }
   
    public float GetBonusIncrease()
    {
        return equippingClothes[clothTypeEnum.shirt].bonusIncrease +
            equippingClothes[clothTypeEnum.pant].bonusIncrease +
            equippingClothes[clothTypeEnum.shoe].bonusIncrease;
    }

    public void EquipCloth(ClothItemSO clothItem, ref ClothItemSO oldCloth)
    {
        oldCloth = equippingClothes[clothItem.clothType];
        equippingClothes[clothItem.clothType] = clothItem;

        // Equip for player, need more elegant way
        if (clothItem.clothType == clothTypeEnum.shirt)
        {
            shirtSprite.sprite = clothItem.clothSprite;
        }
        if (clothItem.clothType == clothTypeEnum.pant)
        {
            pantSprite.sprite = clothItem.clothSprite;
        }
        if (clothItem.clothType == clothTypeEnum.shoe)
        {
            rightShoeSprite.sprite = clothItem.clothSprite;
            leftShoeSprite.sprite = clothItem.clothSprite;
        }
    }
}
