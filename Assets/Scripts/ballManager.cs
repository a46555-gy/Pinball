using UnityEngine;
using UnityEngine.SceneManagement;

public class ballManager : MonoBehaviour
{
    public float upForce = 500f; 
    public float leftForce = 300f;
    public float targetHeight = 5f;

    private Rigidbody2D rb;
    private bool hasTurnedLeft = false;
    
    [SerializeField] private float fallThreshold = -7; 
    
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        LaunchUpward();
    }

    void Update()
    {
        if (!hasTurnedLeft && transform.position.y >= targetHeight)
        {
            MoveLeft();
        }
        
        if (transform.position.y < fallThreshold)
        {
            ResetScene();
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void LaunchUpward()
    {
        rb.AddForce(Vector2.up * upForce);
    }

    void MoveLeft()
    {
        hasTurnedLeft = true;

        rb.AddForce(Vector2.left * leftForce);

        rb.linearVelocity = new Vector2(-leftForce * Time.deltaTime, 0);
    }

    private void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
