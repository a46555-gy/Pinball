using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ballManager : MonoBehaviour
{
    public GameObject starPoint;    
    public Transform spawnPoint;
    
    public float upForce = 500f; 
    public float leftForce = 300f;
    public float targetHeight = 5f;

    private Rigidbody2D rb;
    private bool hasTurnedLeft = false;
    
    [SerializeField] private float fallThreshold = -8;
    [SerializeField] double startX = 4.76;
    [SerializeField] double startY = -5.87;

    private AudioSource audioSource;
    
    public TextMeshProUGUI ScoreNumber;
    public TextMeshProUGUI highScoreNum;
    int scoreTotal = 0;
    int highScoreTotal = 0;

    private const string HighScoreKey = "High Score";
    
    public int scoreBlueBumper = 100;
    public int scoreYellowBumper = 50;
    public int scoreGreenBumper = 500;
    public int scoreGreenButton = 25;
    public int scoreTriangle = 15;
    public int curMultiplier = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        highScoreTotal = PlayerPrefs.GetInt(HighScoreKey, 0);
        highScoreNum.text = highScoreTotal.ToString();

        UpdateScore();
    }

    void Update()
    {
        if (!hasTurnedLeft && transform.position.y >= targetHeight)
        {
            MoveLeft();
        }
        
        if (transform.position.y < fallThreshold)
        {
            Debug.Log($"Ball fell out at {transform.position}, velocity {rb.linearVelocity}");
            ResetScene();
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        if (collision.gameObject.tag == "greenBumper")
        {
            scoreTotal = scoreTotal + scoreGreenBumper*curMultiplier;
            UpdateScore();
        }
        if (collision.gameObject.tag == "blueBumper")
        {
            scoreTotal = scoreTotal + scoreBlueBumper*curMultiplier;
            SpawnRandomStars();
            UpdateScore();
        }
        if (collision.gameObject.tag == "yellowBumper")
        {
            scoreTotal = scoreTotal + scoreYellowBumper*curMultiplier;
            UpdateScore();
        }
        if (collision.gameObject.tag == "triangleBump")
        {
            scoreTotal = scoreTotal + scoreTriangle*curMultiplier;
            UpdateScore();
        }
        if (collision.gameObject.tag == "greenButtons")
        {
            scoreTotal = scoreTotal + scoreGreenButton*curMultiplier;
            UpdateScore();
        }
        if (collision.gameObject.tag == "multiplier1.5")
        {
            curMultiplier = 5;
        }
        if (collision.gameObject.tag == "multiplier1.2")
        {
            curMultiplier = 2;
        }
        if (collision.gameObject.tag == "star")
        {
            scoreTotal += 100;
            UpdateScore();
            Destroy(collision.gameObject);
        }
    }

    void MoveLeft()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        hasTurnedLeft = true;

        rb.AddForce(Vector2.left * leftForce);

        rb.linearVelocity = new Vector2(-leftForce * Time.deltaTime, 0);
    }

    private void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    
    void UpdateScore()
    {
        ScoreNumber.text = scoreTotal.ToString();
        if (scoreTotal > highScoreTotal)
        {
            highScoreTotal = scoreTotal;
            highScoreNum.text = highScoreTotal.ToString();
            PlayerPrefs.SetInt(HighScoreKey, highScoreTotal);
            PlayerPrefs.Save();
        }
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > 300f) rb.linearVelocity = rb.linearVelocity.normalized * 300f;
    }
    
    void OnDestroy() { Debug.Log("Ball destroyed!\n" + System.Environment.StackTrace); }
    void OnDisable() { Debug.Log("Ball disabled!"); }
    
    public int minStars = 0;          
    public int maxStars = 1;         

    private void SpawnRandomStars()
    {
        int randomCount = UnityEngine.Random.Range(minStars, maxStars + 1);

        for (int i = 0; i < randomCount; i++)
        {
            Vector3 positionToSpawn = transform.position;
            
            Vector3 randomOffset = new Vector3(
                UnityEngine.Random.Range(-2f, 2f),
                UnityEngine.Random.Range(-2f, 2f),
                UnityEngine.Random.Range(-2f, 2f)
            );
            
            Instantiate(starPoint, positionToSpawn + randomOffset, Quaternion.identity);
        }
    }
}