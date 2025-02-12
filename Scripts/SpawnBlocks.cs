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
//     public bool CheckBounds(List<Vector3Int> positions, Vector3Int currentPosition, Vector3Int direction)
//     {
//         foreach (var position in positions)
//         {
//             if(position.x + direction.x + currentPosition.x < leftBounds || position.x + direction.x + currentPosition.x > rightBounds || inactive.HasTile(position + direction + currentPosition))
//             {
//                 return false;
//             }
//         }
//         return true;
//     }
//     void Move()
//     {
//         Vector3Int currentPosition = Vector3Int.RoundToInt(active.transform.position);
//         if(Input.GetKeyDown(KeyCode.A) && CheckBounds(activeBlocks, currentPosition, Vector3Int.left))
//         {
//             active.transform.position = currentPosition + Vector3Int.left;
        
//         } else if (Input.GetKeyDown(KeyCode.D) && CheckBounds(activeBlocks, currentPosition, Vector3Int.right))
//         {
//             active.transform.position = currentPosition + Vector3Int.right;
//         }
//     }
//     void MakeActiveFall()
//     {
//         Vector3Int currentPosition = Vector3Int.RoundToInt(active.transform.position);
//         if(CheckFloor(activeBlocks, currentPosition))
//         {
//             active.transform.position = currentPosition + Vector3Int.down;
//         } else
//         {
//             Convert(currentPosition);
//         }
        
//     }

//     bool CheckFloor(List<Vector3Int> positions, Vector3Int currentPosition)
//     {
//         foreach (var position in positions.ToList())
//         {
//             if(position.y + Vector3Int.down.y + currentPosition.y < floor || inactive.HasTile(position + Vector3Int.down + currentPosition))
//             {
//                 return false;
//             }
//         }
//         return true;
//     }
//     void Convert(Vector3Int currentPosition)
//     {
//         foreach (var activeBlock in activeBlocks)
//         {
//             inactive.SetTile(activeBlock + currentPosition, active.GetTile(activeBlock));
//         }
//         active.ClearAllTiles();
//         active.transform.position = spawnPoint + Vector3Int.right;
//         blockState = 0;
//     }

//     void MakeInactiveFall()
//     {
//         gameSpeed = 0.5f;
//         bool anyTileFell = false;
//         foreach (Vector3Int position in bounds.allPositionsWithin)
//         {
//             TileBase tile = inactive.GetTile(position);
//             if (tile != null && CheckIfEmptyBellow(position))
//             {
//                 inactive.SetTile(position + Vector3Int.down, tile);
//                 inactive.SetTile(position, null);
//                 anyTileFell = true;
//             }
//         }
//         if(anyTileFell)
//         {
//             blockState = 0;
//         } else 
//         {
//             blockState = 2;
//         }
//     }



//     bool CheckIfEmptyBellow(Vector3Int position)
//     {
//         if(inactive.HasTile(position + Vector3Int.down) || position.y + Vector3Int.down.y < floor)
//         {
//             return false;
//         }
//         return true;
//     }
//     bool CheckIfAboveHeightLimit()
//     {
//         for (int x = leftBounds; x <= rightBounds; x++)
//         {
//             if(inactive.HasTile(new Vector3Int(x, heightLimit, 0))){
//                 return true;
//             }
//         }
//         return false;
//     }
//     void ScrambleColorsKeyboard()
//     {
//         if(Input.GetKeyDown(KeyCode.W))
//         {
//             ScrambleColors();
//         }
//     }
//     public void ScrambleColors()
//     {
//         TileBase lastTile = active.GetTile(activeBlocks.Last());
//         for (int i = activeBlocks.Count - 1; i > 0; i--)
//         {
//             active.SetTile(activeBlocks[i], active.GetTile(activeBlocks[i - 1]));
//         }
//         active.SetTile(activeBlocks[0], lastTile);
//     }
//     void FallFasterKeyboard()
//     {
//         if(Input.GetKeyDown(KeyCode.S))
//         {
//             FallFaster();
//         }
//     }
//     public void FallFaster()
//     {
//         gameSpeed = 0.1f;
//     }
//     // Update is called once per frame
//     void Update()
//     {   
//         FallFasterKeyboard();
//         ScrambleColorsKeyboard();
//         Move();
//         clock += Time.deltaTime;
//         if (clock > gameSpeed)
//         {   
//             if(blockState == 1)
//             {
//                 clock = 0f;
//                 MakeActiveFall();
//             } else if (blockState == 0)
//             {
//                 clock = 0f;
//                 MakeInactiveFall();
//             } else if (blockState == 2)
//             {
//                 clock = 0f;
//                 deleteBlocks.CheckEveryBlock();
//             }
            
//         }
//         if(CheckIfAboveHeightLimit()){
//             Application.Quit();
//         }
//     }
// }
