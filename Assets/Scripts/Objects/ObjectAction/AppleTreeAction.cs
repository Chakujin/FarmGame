using UnityEngine;

public class AppleTreeAction : MonoBehaviour, IObjectInteractable
{
    public GameObject appleObject;
    public GameObject renderTronco;
    public GameObject TroncoObj;
    private SpriteRenderer _mainRenderer;
    public Transform appleSpawn;

    private Animator _animator;
    private bool _Droped = false;
    private bool _finish = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _mainRenderer = GetComponent<SpriteRenderer>();
        renderTronco.SetActive(false);
    }

    public void OnInteract()
    {
        if(_Droped == false)
        {
            _animator.SetBool("Hited", true);
            Instantiate(appleObject, appleSpawn);
            _Droped = true;
        }
        else if(_Droped == true && _finish == false)
        {
            _finish = true;
            renderTronco.SetActive(true);
            _mainRenderer.enabled = false;
            Instantiate(TroncoObj, appleSpawn);
        }
    }
}
