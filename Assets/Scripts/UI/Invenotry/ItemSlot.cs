using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//SCRIPT ITEMS UI VISUAL INVENTORY
public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private GameObject _stackObj;

    [SerializeField]
    private TextMeshProUGUI _stackNumber;

    public string nameId;
    public bool isSeed;
    public ItemData itemDataSlot;

    public void Set(InventoryItem item)
    {
        _itemIcon.sprite = item.data.itemImage;
        nameId = item.data.id;
        isSeed = item.data.seeds;
        itemDataSlot = item.data;

        if(item.stackSize <= 1)
        {
            _stackObj.SetActive(false);
            return;
        }

        _stackNumber.text = item.stackSize.ToString();
    }
}
