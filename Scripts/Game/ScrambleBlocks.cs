using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScrambleBlocks : MonoBehaviour
{
    public SpawnBlocks spawnBlocks;
    public Tilemap active;
    private List<TileBase> newColors;

    public void Scramble()
    {   
        newColors = new List<TileBase>();
        TileBase firstColor = spawnBlocks.activeColors.First();
        for (int i = 1; i < spawnBlocks.activeColors.Count; i++)
        {
            newColors.Add(spawnBlocks.activeColors[i]);
        }
        newColors.Add(firstColor);
        spawnBlocks.activeColors.Clear();
        spawnBlocks.activeColors.AddRange(newColors);
        active.ClearAllTiles();
        active.SetTiles(spawnBlocks.activeBlocks.ToArray(), spawnBlocks.activeColors.ToArray());
    }
}
