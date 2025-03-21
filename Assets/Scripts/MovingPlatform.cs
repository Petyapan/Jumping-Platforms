using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private Vector3 _nextPosition;

    public Vector3 pointA; // World position of point A
    public Vector3 pointB; // World position of point B

    private void Start()
    {
        // Set the initial target position to pointB
        _nextPosition = pointB;
    }

    private void Update()
    {
        // Move the platform toward the next position
        transform.position = Vector3.MoveTowards(
            transform.position,
            _nextPosition,
            speed * Time.deltaTime
        );

        // Switch target position when the platform reaches the current target
        if (transform.position == _nextPosition)
        {
            _nextPosition = (_nextPosition == pointA) ? pointB : pointA;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
