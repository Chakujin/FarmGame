using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT TO INTERACT OBJECTS WITH THE PLAYER TO ADD INVENOTRY
public class ObjectScript : MonoBehaviour
{
    public ItemData data;

    public void PickUp()
    {
        FindObjectOfType<AudioManager>().Play("TakeItem");
        InventoryScript.Instance.Add(data); //Add to invenotry
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUp();
        }
    }
}
