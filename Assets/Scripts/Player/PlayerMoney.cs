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

    private PlayerEquipment equipment;

    private void Start()
    {
        equipment = GetComponent<PlayerEquipment>();

        increaseText.text = increaseAmount + " $ / sec";
    }

    private void Update()
    {
        // Add money every 1 second
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            IncreaseAmount = equipment.GetBonusIncrease();
            CurrentMoney += IncreaseAmount;
            timer = 0;
        }
    }

}
