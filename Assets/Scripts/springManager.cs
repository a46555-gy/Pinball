using UnityEngine;

public class springManager : MonoBehaviour
{
    [SerializeField] private float maxDistance = 3.0f;      
    [SerializeField] private float minDistance = 0.5f;     
    [SerializeField] private float compressionSpeed = 2.0f;


    private SpringJoint2D springJoint;
    private float targetDistance;

    void Start()
    {
        springJoint = GetComponent<SpringJoint2D>();
        targetDistance = maxDistance;
        springJoint.distance = targetDistance;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            targetDistance -= compressionSpeed * Time.deltaTime;
        }
        else
        {
            targetDistance = maxDistance;
        }

        targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);

        springJoint.distance = targetDistance;
    }
}