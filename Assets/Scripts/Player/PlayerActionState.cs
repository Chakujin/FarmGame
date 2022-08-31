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

    [SerializeField]
    private ItemData _axeData;
    
    [SerializeField]
    private ItemData _sprinklerData;
    
    [SerializeField]
    private ItemData _hoeData;
    #endregion

    private ItemData lastItem;

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
        switch(lastItem.id)
        {
            case _axeData.id:      
                break;
        }
        */

        //COMO OPTIMIZO ESTE IF SI EL SWITCH NO ME VA?
        if(lastItem != null)
        {
            if (lastItem.seeds == false)
            {
                if (lastItem.id == _axeData.id)
                {
                    StateMachine.playerAnimator.SetTrigger("ActionAxe");
                    StateMachine.ChangeState(StateMachine.PublicActionAxe);
                }
                //Sprinkler action
                else if (lastItem.id == _sprinklerData.id)
                {
                    StateMachine.playerAnimator.SetTrigger("ActionSprinkler");
                    StateMachine.ChangeState(StateMachine.PublicActionSprinkler);
                }
                //Hoe action
                else if (lastItem.id == _hoeData.id)
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
            else if (lastItem.seeds == true)
            {

                onCallSeedSelectedCallBack.Invoke(lastItem);
                StateMachine.ChangeState(StateMachine.PlayerActionPlant);
            }
        }
        else
        {
            StateMachine.ChangeState(StateMachine.PlayerMoveState);
        }
    }

    public void ActionsItems(ItemData data)
    {
        lastItem = data;
    }
}
