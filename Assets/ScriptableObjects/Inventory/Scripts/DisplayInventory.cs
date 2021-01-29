using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    private Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }
    
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Conteiner.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Conteiner[i]))
            {
                itemsDisplayed[inventory.Conteiner[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Conteiner[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Conteiner[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Conteiner[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Conteiner[i], obj);
            }
            if (inventory.Conteiner[i].amount == 0)
            {
                Destroy(itemsDisplayed[inventory.Conteiner[i]]);
                inventory.DeleteItem(i);
            }
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Conteiner.Count; i++)
        {
            var obj = Instantiate(inventory.Conteiner[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Conteiner[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Conteiner[i], obj);
        }
    }
    
}
