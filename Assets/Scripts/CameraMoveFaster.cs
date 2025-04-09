using UnityEngine;

public class CameraMoveFaster : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 1.5f;
    [SerializeField] private float speedIncrease = 0.1f;
    [SerializeField] private float maxSpeed = 5f;

    private float currentSpeed;

    private void Start()
    {
        currentSpeed = baseSpeed;
    }

    private void Update()
    {
        currentSpeed = Mathf.Min(currentSpeed + speedIncrease * Time.deltaTime, maxSpeed);
        transform.position += new Vector3(0, currentSpeed * Time.deltaTime, 0);
        Debug.Log($"Current Speed: {currentSpeed}, Position: {transform.position}");
    }

}