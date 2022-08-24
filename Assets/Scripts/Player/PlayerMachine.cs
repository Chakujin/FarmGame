using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMachine : MonoBehaviour
{
    //Machine States
    private MonoBehaviour PlayerActualState;

    public MonoBehaviour PlayerInicialState;
    public MonoBehaviour PlayerMoveState;
    public MonoBehaviour PlayerActionState;

    //ACTIONS
    public MonoBehaviour PlayerActionHoe;
    public MonoBehaviour PublicActionAxe;
    public MonoBehaviour PublicActionSprinkler;
    public MonoBehaviour PlayerActionPlant;

    [SerializeField]
    private List<MonoBehaviour> _stateList;

    //Variables
    public Animator playerAnimator;


    // Start is called before the first frame update
    void Start()
    {
        //State Machine
        foreach(MonoBehaviour script in _stateList)
        {
            script.enabled = false;
        }

        ChangeState(PlayerInicialState);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeState(PlayerActionState);
        }
    }

    public void ChangeState(MonoBehaviour newState)
    {
        if (PlayerActualState != null)
        {
            PlayerActualState.enabled = false;
        }
        PlayerActualState = newState;
        PlayerActualState.enabled = true;
    }
}
