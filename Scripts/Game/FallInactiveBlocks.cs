using UnityEngine;
using UnityEngine.Tilemaps;

public class FallInactiveBlocks : MonoBehaviour
{
    public Tilemap inactive;
    public BoundsInt bounds;
    public FallActiveBlocks fallActiveBlocks;
    public BlockControler blockControler;
    private TileBase tile;
    private bool anyTileFell = false;
    public void InactiveFall()
    {   anyTileFell = false;
        foreach (Vector3Int position in bounds.allPositionsWithin)
        {
            tile = inactive.GetTile(position);
            if (tile == null) continue;
            if(CheckIfEmptyBellow(position))
            {
                inactive.SetTile(position + Vector3Int.down, tile);
                inactive.SetTile(position, null);
                anyTileFell = true;
            }
        }
        if(anyTileFell)
        {
            InactiveFall();
        }
        blockControler.state = 4;
    }
    bool CheckIfEmptyBellow(Vector3Int position)
    {
        if(inactive.HasTile(position + Vector3Int.down))
        {
            return false;
        }
        if(position.y < fallActiveBlocks.ground)
        {
            return false;
        }
        return true;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
