using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActionHoeState : MonoBehaviour
{
    //State Machine
    private PlayerMachine StateMachine;

    //Variables
    public Transform hitTransform;

    public Tilemap mapTrigger;
    public Tilemap terrainMap;
    public TileBase textureNewTerrain;

    private Vector3Int _gridPos;
    private bool _firtsTime = true;

    // Start is called before the first frame update
    void Awake()
    {
        StateMachine = GetComponent<PlayerMachine>();
    }

    private void OnEnable()
    {
        if(_firtsTime == false)
        {
            _gridPos = terrainMap.WorldToCell(hitTransform.position);
            PlaceTile();
        }
        else
        {
            _firtsTime = false;
        }
    }

    private void PlaceTile()
    {
        if (terrainMap.GetTile(_gridPos) != null) // If have terrain can action
        {
            mapTrigger.SetTile(_gridPos, textureNewTerrain); // Print terrain to put seeds
            StateMachine.ChangeState(StateMachine.PlayerMoveState);
        }
        else // else do nothing
        {
            StateMachine.ChangeState(StateMachine.PlayerMoveState);
        }
    }
}
