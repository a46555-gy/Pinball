using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public Text scoreText;
    int scoreNum;
    void Start()
    {
        scoreNum = 0;
        scoreText.text = "Score: "+scoreNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
