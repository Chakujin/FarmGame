using UnityEngine;

public class PlayerActionAxeState : MonoBehaviour
{   
    // ACTION AXE

    //State Machine
    private PlayerMachine StateMachine;

    //Variables
    public Transform hitTransform;
    public Vector2 sizeCube;
    public LayerMask interactableAxeLayer;

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<PlayerMachine>();
    }

    private void FixedUpdate()
    {
        Collider2D[] detectObject = Physics2D.OverlapBoxAll(hitTransform.position, sizeCube, 0, interactableAxeLayer);

        foreach (Collider2D obj in detectObject)
        {
            IObjectInteractable _interactable = obj.GetComponent<IObjectInteractable>(); //Get the interface
            if(_interactable != null) //if the interface is not empty
            {
                HitObject(_interactable);
            }
        }
        StateMachine.ChangeState(StateMachine.PlayerMoveState);
    }

    private void HitObject(IObjectInteractable obj)
    {
        obj.OnInteract();
        StateMachine.ChangeState(StateMachine.PlayerMoveState);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(hitTransform.position, sizeCube);
    }
}
