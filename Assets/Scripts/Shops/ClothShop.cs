using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothShop : MasterShop
{
    [SerializeField]
    private List<ClothItemSO> shirts;
    [SerializeField]
    private List<ClothItemSO> pants;
    [SerializeField]
    private List<ClothItemSO> shoes;

    [SerializeField]
    private Button itemButton;

    [SerializeField]
    private GridLayoutGroup shirtGrid;
    [SerializeField]
    private GridLayoutGroup pantGrid;
    [SerializeField]
    private GridLayoutGroup shoeGrid;

    protected override void Start()
    {     
        shirts = new List<ClothItemSO>();
        pants = new List<ClothItemSO>();
        shoes = new List<ClothItemSO>();

        base.Start();
    }

    protected override void RefreshShop()
    {
        foreach (ClothItemSO shirt in shirts)
        {
            Button button = Instantiate(itemButton);
            button.transform.SetParent(shirtGrid.transform);
        }
    }
}
