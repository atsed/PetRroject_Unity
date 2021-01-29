using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Conteiner = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Conteiner.Count; i++)
        {
            if (Conteiner[i].item == _item)
            {
                Conteiner[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            Conteiner.Add(new InventorySlot(_item, _amount));
        }

    }

    public void DeleteItem(int i)
    {
        Conteiner.RemoveAt(i);
    }
    
    public void DeleteAmount(KeyValuePair<InventorySlot,GameObject> variable, int value)
    {
        Conteiner[Conteiner.IndexOf(variable.Key)].DeleteAmount(value);
    }
    
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
    public void DeleteAmount(int value)
    {
        amount -= value;
    }
}