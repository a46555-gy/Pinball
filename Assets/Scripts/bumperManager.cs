using UnityEngine;

public class bumperManager : MonoBehaviour
{
    [SerializeField] private float popScale = 1.25f;   
    [SerializeField] private float growSpeed = 20f;   
    [SerializeField] private float shrinkSpeed = 8f;  
    [SerializeField] private float holdTime = 0.1f;    

    private Vector3 ogSize;
    private float holdTimer;
    private bool isPopped;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        ogSize = transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        isPopped = true;
        holdTimer = holdTime;
    }

    void Update()
    {
        if (isPopped)
        {
            holdTimer -= Time.deltaTime;
            if (holdTimer <= 0f)
            {
                isPopped = false;
            }
        }

        Vector3 targetSize = isPopped ? ogSize * popScale : ogSize;
        float speed = isPopped ? growSpeed : shrinkSpeed;

        transform.localScale = Vector3.Lerp(transform.localScale, targetSize, Mathf.Min(1f, speed * Time.deltaTime));

        if (!isPopped && (transform.localScale - ogSize).sqrMagnitude < 0.00001f)
        {
            transform.localScale = ogSize;
        }
    }
}