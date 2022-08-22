using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionState : MonoBehaviour
{
    // ONLY ACTION PLAYER

    //State Machine
    private PlayerMachine StateMachine;

    #region DATA_TOOLS
    //Herramientas script
    private string _lastItemName;

    [SerializeField]
    private ItemData _axeData;
    
    [SerializeField]
    private ItemData _sprinklerData;
    
    [SerializeField]
    private ItemData _hoeData;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<PlayerMachine>();

        ItemSelected.onCallNameItemSelectedCall += ActionsItems;
    }

    private void Update()
    {
        //COMO OPTIMIZO ESTE IF SI EL SWITCH NO ME VA?
        //Axe action
        if(_lastItemName == _axeData.id)
        {
            StateMachine.ChangeState(StateMachine.PublicActionAxe);
        }
        //Sprinkler action
        else if (_lastItemName == _sprinklerData.id)
        {
            StateMachine.ChangeState(StateMachine.PublicActionSprinkler);
        }
        //Hoe action
        else if (_lastItemName == _hoeData.id)
        {
            StateMachine.ChangeState(StateMachine.PlayerActionHoe);
        }
        else
        {
            StateMachine.ChangeState(StateMachine.PlayerMoveState);
        }
    }

    public void ActionsItems(string name)
    {
        _lastItemName = name;
    }
}
