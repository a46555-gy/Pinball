using UnityEngine;

public class starManager : MonoBehaviour
{
    [SerializeField] private float destroyThreshold = -8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < destroyThreshold)
        {
            Destroy(this);
        }   
    }
}
