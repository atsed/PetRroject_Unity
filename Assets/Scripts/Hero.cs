using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject interactionButton;
    public GameObject takeButtonObj;
    public Button takeButton; 
    private Component item;


    private void Start()
    {
        takeButton.onClick.AddListener(AddToInventory);
    }
    void AddToInventory()
    {
        takeButtonObj.SetActive(false);
        inventory.AddItem(item.GetComponent<Item>().item, 1);
        Destroy(item.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Merchant")
        {
            interactionButton.SetActive(true);
        }

        item = other.GetComponent<Item>();
        if (item)
        {
            takeButtonObj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Merchant")
        {
            interactionButton.SetActive(false);
        }

        var item = other.GetComponent<Item>();
        if (item)
        {
            takeButtonObj.SetActive(false);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Conteiner.Clear();
    }
}