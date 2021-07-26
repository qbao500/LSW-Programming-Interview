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

    virtual protected void Start()
    {
        shopCanvas.enabled = false;     
    }

    protected abstract void RefreshShop();

    public virtual void OpenShop()
    {
        shopCanvas.enabled = true;
        RefreshShop();
    }

    public virtual void CloseShop()
    {
        shopCanvas.enabled = false;
    }
}
