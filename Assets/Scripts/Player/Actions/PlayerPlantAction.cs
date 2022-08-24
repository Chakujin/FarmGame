using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerPlantAction : MonoBehaviour
{
    //SCRIPT TO PLANT SEEDS

    //State Machine
    private PlayerMachine StateMachine;

    //Variables
    public Tilemap sandMap;
    public Transform hitTransform;

    public GameObject _plantObject;
    private Vector3Int _cordenades;
    private bool _firtsTime = true;

    // Start is called before the first frame update
    void Awake()
    {
        StateMachine = GetComponent<PlayerMachine>();
    }

    private void OnEnable()
    {
        if( _firtsTime == false)
        {
            PlantAction();
        }
        else
        {
            _firtsTime = false;
        }
    }

    private void PlantAction()
    {
        _cordenades = sandMap.WorldToCell(hitTransform.position);


        if (sandMap.GetTile(_cordenades) != null) // If have terrain can action
        {
            Vector3 posIns = sandMap.GetCellCenterLocal(_cordenades); //Get center cell

            //Add plant
            Instantiate(_plantObject, posIns, transform.localRotation);
            StateMachine.ChangeState(StateMachine.PlayerMoveState);
        }
        else // else do nothing
        {
            StateMachine.ChangeState(StateMachine.PlayerMoveState);
        }
    }
}
