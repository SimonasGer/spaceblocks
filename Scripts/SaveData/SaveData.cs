using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

[System.Serializable]
public class SaveData
{
    public int score;
    public float gameSpeed;
    public List<Vector3Int> previewBlocks;
    public List<TileBase> previewBlockColors;
    public List<Vector3Int> activeBlocks;
    public List<TileBase> activeBlockColors;
    public List<Vector3Int> fallenBlockPositions;
    public List<TileBase> fallenBlockColors;
}
