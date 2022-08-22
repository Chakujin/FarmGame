using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public List<GameObject> itemList;

    public delegate void onUpdateInventory();
    public event onUpdateInventory onUpdateInventoryEvent;

    private void Start()
    {
        InventoryScript.Instance.onInvenotryChangedEventCallback += OnUpdateInvenotry;
    }

    public void OnUpdateInvenotry()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.transform.gameObject);
        }
        itemList.Clear();
        DrawnInventory();
    }

    public void DrawnInventory()
    {
        foreach( InventoryItem item in InventoryScript.Instance.inventory)
        {
            AddInventorySlot(item);
        }
        if (onUpdateInventoryEvent != null)
        {
            onUpdateInventoryEvent.Invoke();
        }
    }

    public void AddInventorySlot(InventoryItem item)
    {
        Debug.Log("Print inventory");
        GameObject obj = Instantiate(itemSlotPrefab);
        obj.transform.SetParent(transform, false);

        itemList.Add(obj);

        ItemSlot slot = obj.GetComponent<ItemSlot>();
        slot.Set(item);
    }
}
