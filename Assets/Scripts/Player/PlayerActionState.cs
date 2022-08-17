using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionState : MonoBehaviour
{
    // ONLY ACTION PLAYER

    //State Machine
    private PlayerMachine StateMachine;
    private PlayerMoveState playerMoveState;

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<PlayerMachine>();
        playerMoveState = GetComponent<PlayerMoveState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
