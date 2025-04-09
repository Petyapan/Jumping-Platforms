using UnityEngine;

public class WaterFollow : MonoBehaviour
{
    [SerializeField] private Transform CameraMoveFast;
    [SerializeField] private float verticalOffset = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(CameraMoveFast.position.x, CameraMoveFast.position.y - verticalOffset, 0);
    }
}
