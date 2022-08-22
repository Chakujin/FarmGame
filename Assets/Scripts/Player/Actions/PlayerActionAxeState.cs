using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionAxeState : MonoBehaviour
{   
    // ACTION AXE

    //State Machine
    private PlayerMachine StateMachine;

    //Variables
    public Transform hitTransform;
    public Vector2 sizeCube;
    public LayerMask interactableLayer;

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<PlayerMachine>();

        StateMachine.playerAnimator.SetTrigger("ActionAxe");
    }

    private void FixedUpdate()
    {
        Collider2D[] detectObject = Physics2D.OverlapBoxAll(hitTransform.position, sizeCube, 0, interactableLayer);

        foreach (Collider2D obj in detectObject)
        {
            
        }
    }
}
