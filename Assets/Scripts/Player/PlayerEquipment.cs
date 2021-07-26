using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    // Starting clothes
    [SerializeField]
    private ClothItemSO startShirt;
    [SerializeField]
    private ClothItemSO startPant;
    [SerializeField]
    private ClothItemSO startShoe;

    // Current equipments
    private Dictionary<clothTypeEnum, ClothItemSO> equippingClothes;

    private void Start()
    {
        // Initial equipment
        equippingClothes = new Dictionary<clothTypeEnum, ClothItemSO>();
        equippingClothes.Add(clothTypeEnum.shirt, startShirt);
        equippingClothes.Add(clothTypeEnum.pant, startPant);
        equippingClothes.Add(clothTypeEnum.shoe, startShoe);
    }
   
    public float GetBonusIncrease()
    {
        return equippingClothes[clothTypeEnum.shirt].bonusIncrease +
            equippingClothes[clothTypeEnum.pant].bonusIncrease +
            equippingClothes[clothTypeEnum.shoe].bonusIncrease;
    }
}
