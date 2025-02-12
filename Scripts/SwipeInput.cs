// using UnityEngine;
// using UnityEngine.Tilemaps;

// public class SwipeInput : MonoBehaviour
// {
//     private Vector2 touchStart;
//     private Vector2 touchEnd;
//     public Tilemap tilemap;
//     public float minSwipeDistance = 100f;
//     public float tapThreshold = 20f;
//     public SpawnBlocks spawnBlocks;
//     void Update()
//     {
//         DetectSwipe();
//         DetectTap();
//     }

//     void DetectTap()
//     {
//         if (Input.touchCount > 0)
//         {
//             Touch touch = Input.GetTouch(0);

//             switch (touch.phase)
//             {
//                 case TouchPhase.Began:
//                     touchStart = touch.position;
//                     break;

//                 case TouchPhase.Ended:
//                     if (Vector2.Distance(touchStart, touch.position) < tapThreshold)
//                     {
//                         spawnBlocks.ScrambleColors();
//                         Debug.Log("Single Tap Detected!");
//                     }
//                     break;
//             }
//         }
//     }
//     void DetectSwipe()
//     {
//         Vector3Int currentPosition = Vector3Int.RoundToInt(tilemap.transform.position);
//         if (Input.touchCount > 0)
//         {
//             Touch touch = Input.GetTouch(0);

//             switch (touch.phase)
//             {
//                 case TouchPhase.Began:
//                     touchStart = touch.position;
//                     break;

//                 case TouchPhase.Ended:
//                     touchEnd = touch.position;
//                     CheckSwipeDirection(currentPosition);
//                     break;
//             }
//         }
//     }

//     void CheckSwipeDirection(Vector3Int currentPosition)
//     {
//         float swipeDistanceX = touchEnd.x - touchStart.x;
//         float swipeDistanceY = touchEnd.y - touchStart.y;

//         if (Mathf.Abs(swipeDistanceX) > minSwipeDistance)
//         {
//             if (swipeDistanceX > 0 && spawnBlocks.CheckBounds(spawnBlocks.activeBlocks, currentPosition, Vector3Int.right))
//             {
//                 tilemap.transform.position = currentPosition + Vector3Int.right;
//             }
//             else if (swipeDistanceX < 0 && spawnBlocks.CheckBounds(spawnBlocks.activeBlocks, currentPosition, Vector3Int.left))
//             {
//                 tilemap.transform.position = currentPosition + Vector3Int.left;
//             }
//         }
//         if (Mathf.Abs(swipeDistanceY) > minSwipeDistance)
//         {
//             if (swipeDistanceY < 0)
//             {
//                 spawnBlocks.FallFaster();
//             }
//         }
//     }
// }
