using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI increaseText;

    private float timer = 0;

    private float currentMoney;
    public float CurrentMoney
    {
        get => currentMoney;
        set
        {
            currentMoney = value;
            moneyText.text = "$ " + currentMoney;
        }
    }

    private float increaseAmount;
    public float IncreaseAmount 
    {
        get => increaseAmount;
        set
        {
            increaseAmount = value;
            increaseText.text = increaseAmount + " $ / sec";
        }
    }

    public PlayerEquipment Equipment { get; private set; }
    public PlayerInventory Inventory { get; private set; }

    private void Start()
    {
        Equipment = GetComponent<PlayerEquipment>();
        Inventory = GetComponent<PlayerInventory>();

        increaseText.text = increaseAmount + " $ / sec";
    }

    private void Update()
    {
        // Add money every 1 second
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            IncreaseAmount = Equipment.GetBonusIncrease();
            CurrentMoney += IncreaseAmount;
            timer = 0;
        }
    }

    public void SpendMoneyToBuy(float amount, ref ItemSO boughtItem)
    {
        CurrentMoney -= amount;
        Inventory.AddItem(boughtItem);
    }

    public void ReceiveMoney(float amount)
    {
        CurrentMoney += amount;
    }
}
