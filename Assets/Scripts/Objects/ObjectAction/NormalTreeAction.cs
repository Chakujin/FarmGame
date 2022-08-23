using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTreeAction : MonoBehaviour, IObjectInteractable
{
    private SpriteRenderer _basicRenderer;
    public GameObject taledRender;
    public GameObject ItemDroped;
    public Transform itemSpawn;

    private bool _hited = false;

    // Start is called before the first frame update
    void Start()
    {
        _basicRenderer = GetComponent<SpriteRenderer>();
        taledRender.SetActive(false);
    }

    public void OnInteract()
    {
        if(_hited == false)
        {
            _hited = true;
            Instantiate(ItemDroped,itemSpawn);
            _basicRenderer.enabled = false;
            taledRender.SetActive(true);
        }
    }
}
