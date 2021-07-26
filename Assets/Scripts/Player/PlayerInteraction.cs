using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI visitText;

    [HideInInspector]
    public MasterShop currentShop = null;

    private void Start()
    {
        visitText.enabled = false;
    }

    private void Update()
    {
        // Handle Visiting shop
        if (Input.GetKeyDown(KeyCode.F) && currentShop)
        {
            print("Enter: " + currentShop.ShopName);
            currentShop.OpenShop();
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
