using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractionButton : MonoBehaviour
{
    public GameObject interactionButtonObj;
    public Button interactionButton;
    public GameObject inventory;
    public GameObject merchantInventory;

    private void Start()
    {
        interactionButtonObj.SetActive(false);
        interactionButton.onClick.AddListener(SetActiveMerchant);
    }

    private void SetActiveMerchant()
    {
        inventory.SetActive(true);
        merchantInventory.SetActive(true);
    }
}
