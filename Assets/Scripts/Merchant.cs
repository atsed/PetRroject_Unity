using UnityEngine;

public class Merchant : MonoBehaviour
{
    public InventoryObject merchantInventory;
    public ItemObject Apple;
    public ItemObject Pear;
    public ItemObject Axe;
    public ItemObject Bat;
    public ItemObject Knife;
    private void OnApplicationQuit()
    {
        merchantInventory.Conteiner.Clear();
        merchantInventory.AddItem(Apple, Random.Range(1,10));
        merchantInventory.AddItem(Pear, Random.Range(1,10));
        merchantInventory.AddItem(Axe, Random.Range(1,10));
        merchantInventory.AddItem(Bat, Random.Range(1,10));
        merchantInventory.AddItem(Knife, Random.Range(1,10));
    }
}
