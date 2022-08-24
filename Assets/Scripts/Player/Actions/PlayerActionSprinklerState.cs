using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActionSprinklerState : MonoBehaviour
{
    //State Machine
    private PlayerMachine StateMachine;

    //Variables
    public Tilemap terrainMap;
    private Vector3Int _cordenatesTile;


    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<PlayerMachine>();
    }

    private void PutWater()
    {
        
    }
}
