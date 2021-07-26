using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInventory : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    // Set when spawned
    [HideInInspector]
    public Transform inventoryPanel;
    [HideInInspector]
    public PlayerInventory inventory;
    [HideInInspector]
    public ItemSO itemData;

    // For snap back if drop failed
    public bool droppedOnSlot;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        droppedOnSlot = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (droppedOnSlot == false)
        {
            // Detach then attach again to snap back to grid
            transform.SetParent(null);
            transform.SetParent(inventoryPanel, false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        inventory.SetSellPriceText(itemData.SellMoney);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventory.SetSellPriceText(0);
    }
}
