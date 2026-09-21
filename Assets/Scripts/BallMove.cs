using UnityEngine;

public class BallMove : MonoBehaviour
{

    Rigidbody2D myBody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.AddForceY(500f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
