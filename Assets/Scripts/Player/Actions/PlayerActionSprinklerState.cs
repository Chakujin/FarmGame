using UnityEngine;

public class PlayerActionSprinklerState : MonoBehaviour
{
    //ONLY ACTION PUT WATER
    //State Machine
    private PlayerMachine StateMachine;

    //Variables
    public Transform hitTransform;
    public Vector2 sizeCube;
    public LayerMask plantLayer;

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<PlayerMachine>();
    }

    private void FixedUpdate()
    {
        Collider2D[] detectObject = Physics2D.OverlapBoxAll(hitTransform.position, sizeCube, 0, plantLayer);

        foreach(Collider2D plant in detectObject)
        {
            plant.GetComponent<Plants>().OnPlantInteract();
            FindObjectOfType<AudioManager>().Play("Sprinkler");
        }
        StateMachine.ChangeState(StateMachine.PlayerMoveState);
    }
}
