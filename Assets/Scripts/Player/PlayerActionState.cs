using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionState : MonoBehaviour
{
    // ONLY ACTION PLAYER

    //State Machine
    private PlayerMachine StateMachine;

    //Events
    public delegate void onCallSeedSelected(ItemData data);
    public static event onCallSeedSelected onCallSeedSelectedCallBack; // Send type of seeds to PlayerPlantAction

    #region DATA_TOOLS
    //Herramientas script
    private string _lastItemName;
    private bool _lastSeed;

    [SerializeField]
    private ItemData _axeData;
    
    [SerializeField]
    private ItemData _sprinklerData;
    
    [SerializeField]
    private ItemData _hoeData;
    #endregion

    #region DATA_SEEDS

    [SerializeField]
    private ItemData _tomatoeSeeds;

    [SerializeField]
    private ItemData _wheatSeeds;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<PlayerMachine>();
    }

    private void OnEnable()
    {
        ItemSelected.onCallNameItemSelectedCall += ActionsItems;
    }

    private void Update()
    {
        /*
        switch(_lastItemName)
        {
            case _axeData.id:      
                break;
        }
        */

        //COMO OPTIMIZO ESTE IF SI EL SWITCH NO ME VA?
        
        if(_lastSeed == false)
        {
            if (_lastItemName == _axeData.id)
            {
                StateMachine.playerAnimator.SetTrigger("ActionAxe");
                StateMachine.ChangeState(StateMachine.PublicActionAxe);
            }
            //Sprinkler action
            else if (_lastItemName == _sprinklerData.id)
            {
                StateMachine.playerAnimator.SetTrigger("ActionSprinkler");
                StateMachine.ChangeState(StateMachine.PublicActionSprinkler);
            }
            //Hoe action
            else if (_lastItemName == _hoeData.id)
            {
                StateMachine.playerAnimator.SetTrigger("ActionHoe");
                StateMachine.ChangeState(StateMachine.PlayerActionHoe);
            }
            //NO ACTIONS
            else
            {
                StateMachine.ChangeState(StateMachine.PlayerMoveState);
            }
        }
        
        //If seeds selected
        else if (_lastSeed == true)
        {
            if(_lastItemName == _tomatoeSeeds.id)
            {
                onCallSeedSelectedCallBack.Invoke(_tomatoeSeeds);
                StateMachine.ChangeState(StateMachine.PlayerActionPlant);
            }
            if (_lastItemName == _wheatSeeds.id)
            {
                onCallSeedSelectedCallBack.Invoke(_wheatSeeds);
                StateMachine.ChangeState(StateMachine.PlayerActionPlant);
            }
        }
    }

    public void ActionsItems(string name , bool seed)
    {
        _lastItemName = name;
        _lastSeed = seed;
    }
}
