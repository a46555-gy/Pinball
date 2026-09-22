using System;
using UnityEngine;

public class multiplierBumper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Sprite newSprite; 
    [SerializeField] private Sprite ogSprite;
    
    Vector3 ogSize;
    Vector3 targetSize = new Vector3(.2f, .2f, 1f);
    public float lerpSpeed = 1f;
    
    private float timer = 0f;

    int counter = 0;
    bool changeBack = false;
    bool timerStart = false;
    bool startSizeChange = false;
    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ogSize = transform.localScale;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (counter != 1)
            {
                startSizeChange = true;
                timerStart = true;
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (ogSprite != null && changeBack)
            {
                spriteRenderer.sprite = ogSprite;
                startSizeChange = false;
                changeBack = false;
                counter = 0;
            }
        }
    }

    void Update()
    {
        if (startSizeChange)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetSize, lerpSpeed * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, ogSize, lerpSpeed * Time.deltaTime);
        }
       
        
        if (timerStart)
        {
            counter = 1;
            timer += Time.deltaTime;
            if (timer >= 0.3f)
            {
                changeBack = true;
                timerStart = false;
                timer = 0f;
            }
        }
    }
  
}