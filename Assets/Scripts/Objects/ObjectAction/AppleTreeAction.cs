using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeAction : MonoBehaviour, IObjectInteractable
{
    public GameObject appleObject;
    public Transform appleSpawn;

    private Animator _animator;
    private bool _Droped = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnInteract()
    {
        if(_Droped == false)
        {
            _animator.SetBool("Hited", true);
            Instantiate(appleObject, appleSpawn);
            _Droped = true;
        }
    }
}
