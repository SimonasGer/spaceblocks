using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallActiveBlocks : MonoBehaviour
{
    public Tilemap active;
    public Tilemap inactive;
    public BlockControler blockControler;
    public int ground;
    public SpawnBlocks spawnBlocks;
    private List<Vector3Int> newBlocks;
    public bool fast = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newBlocks = new List<Vector3Int>();
    }
    public void Fall()
    {
        foreach (var block in spawnBlocks.activeBlocks)
        {
            if(CheckGround(block))
            {
                fast = false;
                blockControler.state = 3;
                return;
            }
        }
        newBlocks.Clear();
        foreach (var block in spawnBlocks.activeBlocks)
        {
            newBlocks.Add(block + Vector3Int.down);
        }
        spawnBlocks.activeBlocks.Clear();
        spawnBlocks.activeBlocks.AddRange(newBlocks);
        active.ClearAllTiles();
        active.SetTiles(spawnBlocks.activeBlocks.ToArray(), spawnBlocks.activeColors.ToArray());
        if(fast){
            Fall();
        }
    }
    bool CheckGround(Vector3Int position)
    {
        if(inactive.HasTile(position + Vector3Int.down))
        {
            return true;
        }
        if(position.y < ground)
        {
            return true;
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
