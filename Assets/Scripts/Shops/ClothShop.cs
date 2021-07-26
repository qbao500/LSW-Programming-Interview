using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClothShop : MasterShop
{
    [Header("Cloth Datas")]
    [SerializeField]
    private List<ClothItemSO> shirts;
    [SerializeField]
    private List<ClothItemSO> pants;
    [SerializeField]
    private List<ClothItemSO> shoes;

    [Header("Grids")]
    [SerializeField]
    private GridLayoutGroup shirtGrid;
    [SerializeField]
    private GridLayoutGroup pantGrid;
    [SerializeField]
    private GridLayoutGroup shoeGrid;

    [Header("Other")]
    [SerializeField]
    private Button itemButton;
    [SerializeField]
    private TextMeshProUGUI priceText;

    protected override void SetupShop()
    {
        // This can be more elegant if there're more time. Looping GetComponent is not good for performance

        foreach (ClothItemSO shirt in shirts)
        {
            Button button = Instantiate(itemButton);
            button.transform.SetParent(shirtGrid.transform, false);
            button.GetComponent<Image>().sprite = shirt.clothSprite;
            button.GetComponent<ItemShop>().itemData = shirt;
            button.GetComponent<ItemShop>().shop = this;
        }

        foreach (ClothItemSO pant in pants)
        {
            Button button = Instantiate(itemButton);
            button.transform.SetParent(pantGrid.transform, false);
            button.GetComponent<Image>().sprite = pant.clothSprite;
            button.GetComponent<ItemShop>().itemData = pant;
            button.GetComponent<ItemShop>().shop = this;
        }

        foreach (ClothItemSO shoe in shoes)
        {
            Button button = Instantiate(itemButton);
            button.transform.SetParent(shoeGrid.transform, false);
            button.GetComponent<Image>().sprite = shoe.clothSprite;
            button.GetComponent<ItemShop>().itemData = shoe;
            button.GetComponent<ItemShop>().shop = this;
        }
    }

    public override void SetPrice(float price)
    {
        priceText.text = price + "$";

        if (!playerMoney) return;

        if (price == 0)
        {
            priceText.color = Color.white;
            return;
        }

        // Set color if player has enough money to buy (green = enough, red = nope)
        if (price >= playerMoney.CurrentMoney)
        {
            priceText.color = Color.red;
        }
        else if (price < playerMoney.CurrentMoney)
        {
            priceText.color = Color.green;
        }  
    }

    public override void BuyItem(float price, ref ItemSO boughtItem)
    {
        if (!playerMoney) return;

        if (price <= playerMoney.CurrentMoney)
        {
            playerMoney.SpendMoneyToBuy(price, ref boughtItem);
        }
    }
}
