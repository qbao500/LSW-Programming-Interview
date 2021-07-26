using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI visitText;

    [SerializeField]
    private GameObject inventoryCanvas;

    [HideInInspector]
    public MasterShop currentShop = null;

    public bool IsInShop { get; private set; } = false;

    private void Start()
    {
        visitText.enabled = false;
        inventoryCanvas.SetActive(false);
    }

    private void Update()
    {
        // Handle Visiting shop
        if (Input.GetKeyDown(KeyCode.F) && currentShop)
        {
            if (IsInShop)
            {
                currentShop.CloseShop();
                inventoryCanvas.SetActive(false);
                IsInShop = false;
                visitText.text = "[F] Visit " + currentShop.ShopName;
            }
            else
            {
                currentShop.OpenShop();
                inventoryCanvas.SetActive(true);
                IsInShop = true;
                visitText.text = "[F] Get out " + currentShop.ShopName;

                // Set PlayerMoney reference if possible
                if (!currentShop.playerMoney)
                {
                    currentShop.playerMoney = GetComponent<PlayerMoney>();
                }
            }        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Visit zone is Capsule Collider, so check the type and make sure its tag is Shop too
        if (collision.GetType() == typeof(CapsuleCollider2D) && collision.gameObject.CompareTag("Shop"))
        {
            currentShop = collision.gameObject.GetComponent<MasterShop>();
            visitText.enabled = true;
            visitText.text = "[F] Visit " + currentShop.ShopName;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetType() == typeof(CapsuleCollider2D) && collision.gameObject.CompareTag("Shop"))
        {
            currentShop = null;
            visitText.enabled = false;
        }
    }
}
