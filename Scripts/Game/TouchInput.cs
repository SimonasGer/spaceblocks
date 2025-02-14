using UnityEngine;
using UnityEngine.Tilemaps;

public class TouchInput : MonoBehaviour
{
    private Vector2 touchStart;
    private Vector2 touchEnd;
    public Tilemap active;
    public float minSwipeDistance = 100f;
    public float tapThreshold = 20f;
    public ScrambleBlocks scrambleBlocks;
    public MoveBlocks moveBlocks;
    public FallActiveBlocks fallActiveBlocks;
    public void DetectTap()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStart = touch.position;
                    break;

                case TouchPhase.Ended:
                    if (Vector2.Distance(touchStart, touch.position) < tapThreshold)
                    {
                        scrambleBlocks.Scramble();
                        Debug.Log("Single Tap Detected!");
                    }
                    break;
            }
        }
    }
    public void DetectSwipe()
    {
        Vector3Int currentPosition = Vector3Int.RoundToInt(active.transform.position);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStart = touch.position;
                    break;

                case TouchPhase.Ended:
                    touchEnd = touch.position;
                    CheckSwipeDirection(currentPosition);
                    break;
            }
        }
    }

    void CheckSwipeDirection(Vector3Int currentPosition)
    {
        float swipeDistanceX = touchEnd.x - touchStart.x;
        float swipeDistanceY = touchEnd.y - touchStart.y;

        if (Mathf.Abs(swipeDistanceX) > minSwipeDistance)
        {
            if (swipeDistanceX > 0)
            {
                moveBlocks.Move(Vector3Int.right);
            }
            else if (swipeDistanceX < 0)
            {
                moveBlocks.Move(Vector3Int.left);
            }
        }
        if (Mathf.Abs(swipeDistanceY) > minSwipeDistance)
        {
            if (swipeDistanceY < 0)
            {
                fallActiveBlocks.fast = true;
            }
        }
    }
}
