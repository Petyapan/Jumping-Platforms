using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    public float breakDelay = 1.0f; // Time in seconds before the platform breaks

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(BreakPlatform), breakDelay);
        }
    }

    private void BreakPlatform()
    {
        Destroy(gameObject);
    }
}
