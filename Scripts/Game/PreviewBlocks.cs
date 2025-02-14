using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PreviewBlocks : MonoBehaviour
{
    public Vector3Int previewLocation;
    public Tilemap preview;
    public List<Vector3Int> previewBlocks;
    public List<TileBase> previewColors;
    public List<TileBase> activeColors;
    public ShapeData data;
    public TileBase[] tiles;
    private bool gameStarted = true;
    public void ShowPreview()
    {   if(gameStarted && previewBlocks.Count > 0)
        {   
            preview.SetTiles(previewBlocks.ToArray(), previewColors.ToArray());
            gameStarted = false;
            return;
        }
        previewBlocks.Clear();
        previewColors.Clear();
        preview.ClearAllTiles();
        int shape = Random.Range(0, data.shapes.Length);
        foreach (var block in data.shapes[shape].blockPositions)
        {   
            previewBlocks.Add(block + previewLocation);
            int tile = Random.Range(0, tiles.Length);
            previewColors.Add(tiles[tile]);
            preview.SetTile(block + previewLocation, tiles[tile]);
        }
        
    }
}
