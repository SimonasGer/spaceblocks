using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DeleteBlocks : MonoBehaviour
{
    public Tilemap inactive;
    public BoundsInt bounds;
    private List<Vector3Int> matchedBlocks;
    private Vector3Int[][] directions;
    public BlockControler blockControler;
    private bool anyTileDeleted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anyTileDeleted = false;
        matchedBlocks = new List<Vector3Int>();
        directions = new Vector3Int[][]
        {
            new[] { Vector3Int.left, Vector3Int.right },
            new[] { Vector3Int.up, Vector3Int.down },
            new[] { Vector3Int.down + Vector3Int.left, Vector3Int.up + Vector3Int.right },
            new[] { Vector3Int.up + Vector3Int.left, Vector3Int.down + Vector3Int.right }
        };
    }
    void CheckForMatches(Vector3Int position)
    {   
        var tile = inactive.GetTile(position);
        foreach (var direction in directions)
        {
            if (tile == null) continue;
            if(tile == inactive.GetTile(position + direction[0]) && 
                tile == inactive.GetTile(position + direction[1]))
            {
                matchedBlocks.Add(position + direction[0]);
                matchedBlocks.Add(position);
                matchedBlocks.Add(position + direction[1]);
            }
        }
    }
    public void CheckEveryBlock()
    {
        anyTileDeleted = false;
        foreach (Vector3Int position in bounds.allPositionsWithin)
        {
            CheckForMatches(position);
        }
        if(matchedBlocks.Count != 0)
        {
            DeleteMatchedBlocks();
        }
        if(anyTileDeleted)
        {
            blockControler.state = 3;
        } else {
            blockControler.state = 1;
        }
        

    }
    public void DeleteMatchedBlocks()
    {
        foreach (var block in matchedBlocks)
        {
            inactive.SetTile(block, null);
        }
        matchedBlocks.Clear();
        anyTileDeleted = true;
    }
}
