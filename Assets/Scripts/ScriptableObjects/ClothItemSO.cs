using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum clothTypeEnum
{
    none,
    shirt,
    pant,
    shoe,
}

[CreateAssetMenu(fileName = "ClothItemName", menuName = "Items/ClothItem", order = 1)]
public class ClothItemSO : ItemSO
{
    public clothTypeEnum clothType;
    public float bonusIncrease = 1;
    public Sprite clothSprite;
}
