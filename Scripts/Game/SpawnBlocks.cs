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
    private bool gameStarted = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SpawnShape()
    {   if(gameStarted && activeBlocks.Count > 0)
        {
            active.SetTiles(activeBlocks.ToArray(), activeColors.ToArray());
            previewBlocks.previewBlocks.Clear();
            previewBlocks.previewColors.Clear();
            previewBlocks.preview.ClearAllTiles();
            previewBlocks.ShowPreview();
            gameStarted = false;
            return;
        }
        foreach (var block in previewBlocks.previewBlocks)
        {
            activeBlocks.Add(block + spawnPoint - previewBlocks.previewLocation);
        }
        activeColors.AddRange(previewBlocks.previewColors);
        previewBlocks.ShowPreview();
    }
}