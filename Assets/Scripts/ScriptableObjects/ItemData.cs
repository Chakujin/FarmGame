using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Item Data", menuName = "Item")]
public class ItemData : ScriptableObject
{
    //Items Properties
    public Sprite itemImage;
    public string id;
    public GameObject itemPref;
    public bool seeds = false;
}