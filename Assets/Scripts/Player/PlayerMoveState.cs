using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : MonoBehaviour
{
    // ONLY MOVEMENT PLAYER

    //State Machine
    private PlayerMachine StateMachine;

    //Variables
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Transform boxPoint;

    [SerializeField]private Vector2 m_Movement;

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<PlayerMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Movement.x = Input.GetAxisRaw("Horizontal");
        m_Movement.y = Input.GetAxisRaw("Vertical");

        StateMachine.playerAnimator.SetFloat("Horizontal", m_Movement.x);
        StateMachine.playerAnimator.SetFloat("Vertical", m_Movement.y);
        StateMachine.playerAnimator.SetFloat("Speed", m_Movement.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + m_Movement * moveSpeed * Time.fixedDeltaTime);

        boxPoint.localPosition = new Vector2(m_Movement.x, m_Movement.y);
    }
}
