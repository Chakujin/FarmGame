using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab;

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
        DrawnInvenotry();
    }

    public void DrawnInvenotry()
    {
        foreach( InventoryItem item in InventoryScript.Instance.inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item)
    {
        Debug.Log("Print inventory");
        GameObject obj = Instantiate(itemSlotPrefab);
        obj.transform.SetParent(transform, false);

        ItemSlot slot = obj.GetComponent<ItemSlot>();
        slot.Set(item);
    }
}
