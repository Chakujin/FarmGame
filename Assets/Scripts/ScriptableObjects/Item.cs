using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //Data
    private ItemData m_data;

    public Image image;
    public GameObject myObject;

    //Data to ItemManager
    public ItemData Data
    {
        set //Take values from data
        {
            m_data = value;
            image.sprite = m_data.itemImage;
        }
    }
}
