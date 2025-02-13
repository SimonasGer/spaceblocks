using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnBlocks : MonoBehaviour
{   
    public Tilemap active;
    public PreviewBlocks previewBlocks;
    public List<Vector3Int> activeBlocks;
    public List<TileBase> activeColors;
    public Vector3Int spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeBlocks = new List<Vector3Int>();
    }
    public void SpawnShape()
    {   
        foreach (var block in previewBlocks.previewBlocks)
        {
            activeBlocks.Add(block + spawnPoint);
        }
        activeColors.AddRange(previewBlocks.previewColors);
        active.SetTiles(activeBlocks.ToArray(), activeColors.ToArray());
        previewBlocks.ShowPreview();
    }
}