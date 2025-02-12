using UnityEngine;
using UnityEngine.Tilemaps;
public class BlockControler : MonoBehaviour
{
    public Tilemap inactive;
    public int state = 0;
    public PreviewBlocks previewBlocks;
    public SpawnBlocks spawnBlocks;
    public FallActiveBlocks fallActiveBlocks;
    public MoveBlocks moveBlocks;
    public TurnInactive turnInactive;
    public FallInactiveBlocks fallInactiveBlocks;
    public DeleteBlocks deleteBlocks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Cycle), 1.0f, 0.5f);
    }
    void Cycle()
    {
        switch (state)
        {
            case 0:
                PreviewState();
                break;
            case 1:
                SpawnState();
                break;
            case 2:
                MoveState();
                break;
            case 3:
                InactiveState();
                break;
            case 4:
                ClearState();
                break;
            default:
                return;
        }
    }
    void PreviewState()
    {
        Debug.Log("Preview State");
        previewBlocks.ShowPreview();
        state = 1;
    }
    void SpawnState()
    {
        Debug.Log("Spawn State");
        spawnBlocks.SpawnShape();
        state = 2;
    }
    void MoveState()
    {
        Debug.Log("Move State");
        fallActiveBlocks.Fall();
    }
    void InactiveState()
    {
        Debug.Log("Inactive State");
        turnInactive.Turn();
        fallInactiveBlocks.InactiveFall();
    }
    void ClearState()
    {
        Debug.Log("Clear State");
        deleteBlocks.CheckEveryBlock();
    }
    void Update()
    {
        if(state == 2)
        {
            moveBlocks.MoveInput();
        }
    }
}
