using UnityEngine;

public class flipperMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Rigidbody2D rigidBody;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidBody.name == "rightFlipper")
        {
           if (Input.GetKey(KeyCode.Space))
           {
               rigidBody.AddTorque(-350f);
           }
           else 
           {
               rigidBody.AddTorque(350f);
           } 
        }
        if (rigidBody.name == "leftFlipper")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rigidBody.AddTorque(350f);
            }
            else 
            {
                rigidBody.AddTorque(-350f);
            } 
        }
        
    }
}
