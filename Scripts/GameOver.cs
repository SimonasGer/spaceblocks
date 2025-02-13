using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public int ceiling;
    public GameObject gameOverScreen;
    public Tilemap inactive;
    public bool CheckHeightLimit()
    {
        for (int i = -3; i < 3; i++)
        {
            Vector3Int position = new(i, ceiling, -1);
            if(inactive.HasTile(position))
            {
                return true;
            }
        }
        return false;
    }
    public void GameOverScreen(bool show)
    {
        gameOverScreen.SetActive(show);
    }
    public void GameOverControler()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }
}
