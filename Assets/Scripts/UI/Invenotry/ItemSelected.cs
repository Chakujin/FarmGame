using UnityEngine;

public class ItemSelected : MonoBehaviour
{
    public GameObject selection;
    [SerializeField]private int _itemSelected = 0;
    public static ItemSlot ObjectSelectedObj; // Take 
    private InventoryUI _inventoryUI;
    private GameObject _lastSelectedBackground;

    //Event deleagte
    public  delegate void onCallNameItemSelected(ItemData data);
    public static event onCallNameItemSelected onCallNameItemSelectedCall; //seend information to PlayerAction for current item selected

    // Start is called before the first frame update
    void Start()
    {
        _inventoryUI = GetComponent<InventoryUI>();
        _inventoryUI.onUpdateInventoryEvent += OnUpdateInventory;
    }

    private void Update()
    {
        //INPUTS
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
            while (_itemSelected >= _inventoryUI.itemList.Count) // If Length itemList is bigger or equal than my int lenth select item -- length select item
            {
                _itemSelected--;
            }

            Destroy(_lastSelectedBackground);
            ObjectSelectedObj = _inventoryUI.itemList[_itemSelected].GetComponent<ItemSlot>();
            ItemData SelectedData = ObjectSelectedObj.itemDataSlot;

            GameObject obj = Instantiate(selection);
            obj.transform.SetParent(ObjectSelectedObj.transform, false);
            obj.transform.SetSiblingIndex(0);

            _lastSelectedBackground = obj;

            if(onCallNameItemSelectedCall != null)
            {
                onCallNameItemSelectedCall.Invoke(SelectedData); //Event
            }
        }
    }
}
