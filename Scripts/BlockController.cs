using UnityEngine;
using UnityEngine.Tilemaps;
public class BlockControler : MonoBehaviour
{
    public Tilemap inactive;
    public int state = 0;
    public PreviewBlocks previewBlocks;
    public SpawnBlocks spawnBlocks;
    public FallActiveBlocks fallActiveBlocks;
    public MoveBlocks moveBlocks;
    public TurnInactive turnInactive;
    public FallInactiveBlocks fallInactiveBlocks;
    public DeleteBlocks deleteBlocks;
    public Combo combo;
    public GameOver gameOver;
    public TouchInput touchInput;
    public float gameSpeed, gamePace, maxSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Cycle), 1.0f, gameSpeed);
    }
    void Cycle()
    {
        switch (state)
        {
            case 0:
                PreviewState();
                break;
            case 1:
                SpawnState();
                break;
            case 2:
                MoveState();
                break;
            case 3:
                InactiveState();
                break;
            case 4:
                ClearState();
                break;
            case 5:
                OverState();
                break;
            default:
                return;
        }
    }
    void PreviewState()
    {
        Debug.Log("Preview State");
        previewBlocks.ShowPreview();
        state = 1;
    }
    void SpawnState()
    {
        Debug.Log("Spawn State");
        spawnBlocks.SpawnShape();
        combo.ShowCombo(false);
        if(maxSpeed < gameSpeed)
        {
            gameSpeed -= gamePace;
        }
        state = 2;
    }
    void MoveState()
    {
        Debug.Log("Move State");
        fallActiveBlocks.Fall();
    }
    void InactiveState()
    {
        Debug.Log("Inactive State");
        combo.ShowCombo(false);
        turnInactive.Turn();
        fallInactiveBlocks.InactiveFall();
    }
    void ClearState()
    {
        Debug.Log("Clear State");
        deleteBlocks.CheckEveryBlock();
    }
    void OverState()
    {
        Debug.Log("Game Over");
    }
    void Update()
    {
        if(state == 2)
        {
            moveBlocks.MoveInput();
            touchInput.DetectSwipe();
            touchInput.DetectTap();
        }
        if(state == 5)
        {
            gameOver.GameOverScreen(true);
            gameOver.GameOverControler();
        }
    }
}
