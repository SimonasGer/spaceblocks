using UnityEngine;
using UnityEngine.Tilemaps;

public class TurnInactive : MonoBehaviour
{
    public Tilemap active;
    public Tilemap inactive;
    public SpawnBlocks spawnBlocks;
    public void Turn()
    {
        active.ClearAllTiles();
        inactive.SetTiles(spawnBlocks.activeBlocks.ToArray(), spawnBlocks.activeColors.ToArray());
        spawnBlocks.activeBlocks.Clear();
        spawnBlocks.activeColors.Clear();
    }
}
