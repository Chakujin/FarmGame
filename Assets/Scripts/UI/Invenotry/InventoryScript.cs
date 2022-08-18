using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SYSTEM INVENOTRY
public class InventoryScript : MonoBehaviour
{
    public static InventoryScript Instance;

    public delegate void onInvenotryChanged();
    public event onInvenotryChanged onInvenotryChangedEventCallback;

    private Dictionary<ItemData, InventoryItem> _itemDictionary;
    public List<InventoryItem> inventory;

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        _itemDictionary = new Dictionary<ItemData, InventoryItem>();

        Instance = this;
    }

    public void Add(ItemData itemData) //ADD ITEMS
    {
        if(_itemDictionary.TryGetValue(itemData, out InventoryItem value))
        {
            Debug.Log("Add stack in item");
            value.AddStack();

            onInvenotryChangedEventCallback.Invoke(); //UPDATE UI INVENTORY
        }
        else
        {
            Debug.Log("Add new item");
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            _itemDictionary.Add(itemData, newItem);
            onInvenotryChangedEventCallback.Invoke(); //UPDATE UI INVENTORY
        }
    }

    public void Remove(ItemData itemData) //REMOVE ITEMS
    {
        if(_itemDictionary.TryGetValue(itemData, out InventoryItem value))
        {
            value.RemoveStack();

            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                _itemDictionary.Remove(itemData);
            }
        }

        onInvenotryChangedEventCallback.Invoke(); //UPDATE UI INVENTORY
    }
}
