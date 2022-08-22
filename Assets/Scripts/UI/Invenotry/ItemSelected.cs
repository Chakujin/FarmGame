using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelected : MonoBehaviour
{
    public GameObject selection;
    [SerializeField]private int _itemSelected = 0;
    public static ItemSlot ObjectSelectedObj; // Take 
    private InventoryUI _inventoryUI;
    private GameObject _lastSelected;

    //Event deleagte
    public  delegate void onCallNameItemSelected(string name);
    public static event onCallNameItemSelected onCallNameItemSelectedCall;

    // Start is called before the first frame update
    void Start()
    {
        _inventoryUI = GetComponent<InventoryUI>();
        _inventoryUI.onUpdateInventoryEvent += OnUpdateInventory;
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // Add num
        {
            if (_itemSelected < _inventoryUI.itemList.Count - 1 && _itemSelected >= 0)
            {
                if (_itemSelected == _inventoryUI.itemList.Count - 1)
                {
                    _itemSelected = _inventoryUI.itemList.Count - 1;
                }
                else
                {
                    _itemSelected++;
                    OnUpdateInventory();
                }
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (_itemSelected <= _inventoryUI.itemList.Count && _itemSelected >=0)
            {
                if(_itemSelected == 0)
                {
                    _itemSelected = 0;
                }
                else
                {
                    _itemSelected--;
                    OnUpdateInventory();
                }
            }
        }
    }

    public void OnUpdateInventory()
    {
        SelectNewItem();
    }

    public void SelectNewItem()
    {
        if (_inventoryUI.itemList.Count >=1)
        {
            Destroy(_lastSelected);
            ObjectSelectedObj = _inventoryUI.itemList[_itemSelected].GetComponent<ItemSlot>();

            GameObject obj = Instantiate(selection);
            obj.transform.SetParent(ObjectSelectedObj.transform, false);
            obj.transform.SetSiblingIndex(0);

            _lastSelected = obj;

            if(onCallNameItemSelectedCall != null)
            {
                onCallNameItemSelectedCall.Invoke(ObjectSelectedObj.nameId); //Event
            }
        }
    }
}
