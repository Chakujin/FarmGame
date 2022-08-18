using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelected : MonoBehaviour
{
    public GameObject selection;
    [SerializeField]private int _itemSelected = 0;
    private GameObject _itemSelectedObj;
    private InventoryUI _inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        _inventoryUI = GetComponent<InventoryUI>();
        _inventoryUI.onUpdateInventoryEvent += OnUpdateInvenotry;
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if (_itemSelected < _inventoryUI.itemList.Count && _itemSelected >= 0) //FIXEAR
            {
                Debug.Log("Sumo");
                _itemSelected++;
                OnUpdateInvenotry();
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (_itemSelected < _inventoryUI.itemList.Count && _itemSelected >=0) //FIXEAR
            {
                Debug.Log("Resto");
                _itemSelected--;
                OnUpdateInvenotry();
            }
        }
        Debug.Log(_inventoryUI.itemList.Count);
    }

    public void OnUpdateInvenotry()
    {
        SelectNewItem();
    }

    public void SelectNewItem()
    {
        if (_inventoryUI.itemList.Count >=1)
        {
            _itemSelectedObj = _inventoryUI.itemList[_itemSelected];

            GameObject obj = Instantiate(selection);
            obj.transform.SetParent(_itemSelectedObj.transform, false);
        }
    }
}
