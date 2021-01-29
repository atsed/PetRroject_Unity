using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    public Button closeButton;
    public GameObject Inventory;
    public GameObject MerchantInventory;
    
    void Update()
    {
        closeButton.onClick.AddListener(CloseInventory);
    }

    void CloseInventory()
    {
        Inventory.SetActive(false);
        MerchantInventory.SetActive(false);
    }
}
