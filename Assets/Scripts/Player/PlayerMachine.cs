using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMachine : MonoBehaviour
{
    //Machine States
    private MonoBehaviour PlayerActualState;

    public MonoBehaviour PlayerInicialState;
    public MonoBehaviour PlayerMoveState;

    //Variables
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //State Machine
        //PlayerMoveState.enabled = false;
        ChangeState(PlayerInicialState);
    }

    // Update is called once per frame
    void Update()
    {
        
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
