using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class MerchantDisplayInventory : MonoBehaviour
{
    public InventoryObject MerchantInventory;
    public InventoryObject HeroInventory;
    public GameObject BuyLine;
    private Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
        PurchaseItems();
    }

    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < MerchantInventory.Conteiner.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(MerchantInventory.Conteiner[i]))
            {
                itemsDisplayed[MerchantInventory.Conteiner[i]].GetComponentInChildren<TextMeshProUGUI>().text =
                    MerchantInventory.Conteiner[i].amount.ToString("n0");
                itemsDisplayed[MerchantInventory.Conteiner[i]].GetComponentInChildren<Slider>().maxValue =
                    MerchantInventory.Conteiner[i].amount;
            }
            else
            {
                var slotObj = Instantiate(BuyLine, Vector3.zero, Quaternion.identity, transform);
                var itemObj = Instantiate(MerchantInventory.Conteiner[i].item.prefab, new Vector3(-250f, 0, 0),
                    Quaternion.identity, transform);
                itemObj.GetComponentInChildren<TextMeshProUGUI>().text =
                    MerchantInventory.Conteiner[i].amount.ToString("n0");
                slotObj.GetComponentInChildren<Slider>().maxValue = MerchantInventory.Conteiner[i].amount;
                itemObj.transform.parent = slotObj.transform;
                itemsDisplayed.Add(MerchantInventory.Conteiner[i], slotObj);
            }

            if (MerchantInventory.Conteiner[i].amount == 0)
            {
                Destroy(itemsDisplayed[MerchantInventory.Conteiner[i]]);
                MerchantInventory.DeleteItem(i);
            }
        }
    }
//TODO: Убрать говнокод (-250f)
    public void CreateDisplay()
    {
        for (int i = 0; i < MerchantInventory.Conteiner.Count; i++)
        {
            var slotObj = Instantiate(BuyLine, Vector3.zero, Quaternion.identity, transform);
            var itemObj = Instantiate(MerchantInventory.Conteiner[i].item.prefab, new Vector3(-250f, 0, 0),
                Quaternion.identity, transform);
            itemObj.GetComponentInChildren<TextMeshProUGUI>().text =
                MerchantInventory.Conteiner[i].amount.ToString("n0");
            slotObj.GetComponentInChildren<Slider>().maxValue = MerchantInventory.Conteiner[i].amount;
            itemObj.transform.parent = slotObj.transform;
            itemsDisplayed.Add(MerchantInventory.Conteiner[i], slotObj);
        }
    }
    

    public void PurchaseItems()
    {
        foreach (var variable in itemsDisplayed)
        {
            variable.Value.GetComponentInChildren<Button>().onClick
                .AddListener(delegate { Purchase(variable); });
        }
    }

    public void Purchase(KeyValuePair<InventorySlot, GameObject> variable)
    {
        MerchantInventory.DeleteAmount(variable, (int) variable.Value.GetComponentInChildren<Slider>().value);
        HeroInventory.AddItem(variable.Key.item,
            (int) itemsDisplayed[variable.Key].GetComponentInChildren<Slider>().value);
    }
}