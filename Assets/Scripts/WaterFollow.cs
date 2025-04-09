using UnityEngine;

public class WaterFollow : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 0.5f;
    
    void Update() 
    { 
        transform.position += new Vector3(0, riseSpeed * Time.deltaTime, 0);
    }
}