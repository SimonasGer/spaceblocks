using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Tilemaps;
public class AutoSave : MonoBehaviour
{
    public Score score;
    public Tilemap inactive;
    public BlockControler blockControler;
    public PreviewBlocks previewBlocks;
    public SpawnBlocks spawnBlocks;
    public void SaveGame()
    {
        SaveData data = new SaveData
        {
            score = score.score,
            gameSpeed = blockControler.gameSpeed,
            previewBlocks = previewBlocks.previewBlocks,
            previewBlockColors = previewBlocks.previewColors,
            activeBlocks = spawnBlocks.activeBlocks,
            activeBlockColors = spawnBlocks.activeColors,
            fallenBlockPositions = GetInactiveBlocks(),
            fallenBlockColors = GetInactiveColors()
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savegame.json", json);

        Debug.Log("Game Saved!");

        List<Vector3Int> GetInactiveBlocks()
        {
            List<Vector3Int> positions = new();
            BoundsInt bounds = inactive.cellBounds;
            foreach (var position in bounds.allPositionsWithin)
            {
                if (inactive.HasTile(position))
            {
                positions.Add(position);
            }
            }
            return positions;
        }

        List<TileBase> GetInactiveColors()
        {
            List<TileBase> colors = new();
            BoundsInt bounds = inactive.cellBounds;
            foreach (var position in bounds.allPositionsWithin)
            {
                TileBase tile = inactive.GetTile(position);
                if (tile != null)
                {
                    colors.Add(tile);
                }
            }
            return colors;
        }
    }
}
