using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 30; // Limit the game to 30 FPS
    }
}