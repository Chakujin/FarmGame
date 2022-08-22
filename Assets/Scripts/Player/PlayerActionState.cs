using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionState : MonoBehaviour
{
    // ONLY ACTION PLAYER

    //State Machine
    private PlayerMachine StateMachine;

    //Herramientas script
    private string _lastItemName;

    [SerializeField]
    private ItemData _axeData;
    
    [SerializeField]
    private ItemData _sprinklerData;
    
    [SerializeField]
    private ItemData _hoeData;

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<PlayerMachine>();

        ItemSelected.onCallNameItemSelectedCall += ActionsItems;
    }

    private void OnEnable()
    {
        //Axe action
        if(_lastItemName == _axeData.id)
        {

        }
        //Sprinkler action
        if (_lastItemName == _sprinklerData.id)
        {

        }
        //Hoe action
        if (_lastItemName == _hoeData.id)
        {

        }
    }

    public void ActionsItems(string name)
    {
        _lastItemName = name;
    }
}
