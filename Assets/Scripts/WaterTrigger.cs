using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class WaterTrigger : MonoBehaviour
{
    // This method is called when another collider enters the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // You can show a game over screen, or simply restart the level.
            Debug.Log("Game Over: Player has touched the water!");

            // For example, restart the current scene:
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
