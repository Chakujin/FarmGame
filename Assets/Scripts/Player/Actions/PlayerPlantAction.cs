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

    private GameObject _plantObject;
    private Vector3Int _cordenades;
    private bool _firtsTime = true;

    private ItemData _lastItem;
    private bool _havePlant = false;

    // Start is called before the first frame update
    void Awake()
    {
        StateMachine = GetComponent<PlayerMachine>();
        PlayerActionState.onCallSeedSelectedCallBack += LastSeedSelected;
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
        _cordenades = sandMap.WorldToCell(hitTransform.position); //Get cordenades from the cell

        //AÑADIR PLANTAR SOLO SI NO SE H APLANTADO YA
        if (sandMap.GetTile(_cordenades) != null) // If have terrain can action
        {
            //COMPROVE IF THE CELL HAVE PLANT
            foreach( Vector3Int pos in PlantedListScript.PlantedPositions)
            {
                if(pos == _cordenades)
                {
                    _havePlant = true;
                }
                else
                {
                    _havePlant = false;
                }
            }
            //If cell no have plant instantiate plant
            if (_havePlant == false)
            {
                //Remove stack
                InventoryScript.Instance.Remove(_lastItem);

                //Find pos
                Vector3 posIns = sandMap.GetCellCenterLocal(_cordenades); //Get center cell

                //Add plant
                _plantObject = _lastItem.itemPref; //Take the gameobject to instantiate from the ItemData
                Instantiate(_plantObject, posIns, transform.localRotation);
                PlantedListScript.PlantedPositions.Add(_cordenades); // Add cell to the list of the cells planted
            }
            StateMachine.ChangeState(StateMachine.PlayerMoveState);
        }
        else // else do nothing
        {
            StateMachine.ChangeState(StateMachine.PlayerMoveState);
        }
    }

    private void LastSeedSelected(ItemData data) //Update seed data selected
    {
        _lastItem = data;
    }
}
