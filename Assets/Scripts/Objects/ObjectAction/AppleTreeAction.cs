using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeAction : MonoBehaviour, IObjectInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnInteract()
    {
        Debug.Log("Me han golpeado");
    }
}
