using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class MasterShop : MonoBehaviour
{
    [SerializeField]
    private string shopName = "Shop Name";
    public string ShopName 
    {
        get { return shopName; }
        private set { shopName = value; }
    }

    [SerializeField]
    protected Canvas shopCanvas;

    [HideInInspector]
    public PlayerMoney playerMoney = null;

    virtual protected void Start()
    {
        SetupShop();
        shopCanvas.enabled = false;     
    }

    protected abstract void SetupShop();

    public abstract void SetPrice(float price);

    public abstract void BuyItem(float price, ref ItemSO boughtItem);

    public virtual void OpenShop()
    {
        shopCanvas.enabled = true;
    }

    public virtual void CloseShop()
    {
        shopCanvas.enabled = false;
    }
}
