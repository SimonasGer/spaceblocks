using UnityEngine;
using System.IO;
using UnityEngine.Tilemaps;


public class LoadGame : MonoBehaviour
{
    public Score score;
    public BlockControler blockControler;
    public PreviewBlocks previewBlocks;
    public SpawnBlocks spawnBlocks;
    public Tilemap inactive;

    public void Load()
    {
        string path = Application.persistentDataPath + "/savegame.json";

        if (File.Exists(path)) // ✅ Check if a save file exists
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score.score = data.score;
            blockControler.gameSpeed = data.gameSpeed;
            previewBlocks.previewBlocks = data.previewBlocks;
            previewBlocks.previewColors = data.previewBlockColors;
            spawnBlocks.activeBlocks = data.activeBlocks;
            spawnBlocks.activeColors = data.activeBlockColors;
            inactive.SetTiles(data.fallenBlockPositions.ToArray(), data.fallenBlockColors.ToArray());

            blockControler.state = 1;
            Debug.Log("Save File Found");
        } else
        {
            Debug.Log("No Save File Found");
            blockControler.state = 0;
        }
    }
}
