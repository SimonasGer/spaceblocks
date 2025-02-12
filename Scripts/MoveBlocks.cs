using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveBlocks : MonoBehaviour
{
    public SpawnBlocks spawnBlocks;
    public FallActiveBlocks fallActiveBlocks;
    public ScrambleBlocks scrambleBlocks;
    public Tilemap active;
    public Tilemap inactive;
    private List<Vector3Int> newBlocks;
    public float leftBounds;
    public float rightBounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newBlocks = new List<Vector3Int>();
    }
    public void MoveInput()
    {

        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("move left");
            Move(Vector3Int.left);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("move right");
            Move(Vector3Int.right);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Fall Fast");
            fallActiveBlocks.fast = true;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Scramble");
            scrambleBlocks.Scramble();
        }
    }
    void Move(Vector3Int direction)
    {
        foreach (var block in spawnBlocks.activeBlocks)
        {
            if(CheckWall(block, direction))
            {
                Debug.Log("wall found");
                return;
            }
        }
        newBlocks.Clear();
        foreach (var block in spawnBlocks.activeBlocks)
        {
            newBlocks.Add(block + direction);
        }
        spawnBlocks.activeBlocks.Clear();
        spawnBlocks.activeBlocks.AddRange(newBlocks);
        active.ClearAllTiles();
        active.SetTiles(spawnBlocks.activeBlocks.ToArray(), spawnBlocks.activeColors.ToArray());
    }
    bool CheckWall(Vector3Int position, Vector3Int direction)
    {
        Vector3Int newPos = position + direction;
        if (newPos.x < leftBounds || newPos.x > rightBounds)
        {
            return true;
        }
        if (inactive.HasTile(newPos))
        {
            return true;
        }

        return false;
    }
}
