using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public Button inventoryButton;
    public GameObject Inventory;

    void Start()
    {
        inventoryButton.onClick.AddListener(SetActiveInventory);
    }

    void SetActiveInventory()
    {
        Inventory.SetActive(true);
    }
    
}
