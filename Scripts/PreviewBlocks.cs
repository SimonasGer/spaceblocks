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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        previewBlocks = new List<Vector3Int>();
    }
    public void ShowPreview()
    {   
        previewBlocks.Clear();
        previewColors.Clear();
        preview.ClearAllTiles();
        int shape = Random.Range(0, data.shapes.Length);
        foreach (var block in data.shapes[shape].blockPositions)
        {   
            previewBlocks.Add(block);
            int tile = Random.Range(0, tiles.Length);
            previewColors.Add(tiles[tile]);
            preview.SetTile(previewLocation + block, tiles[tile]);
        }
        
    }
}
