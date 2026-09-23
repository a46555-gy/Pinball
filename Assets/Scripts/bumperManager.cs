using System;
using UnityEngine;

public class bumperManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Sprite newSprite; 
    [SerializeField] private Sprite ogSprite;
    
    Vector3 ogSize;
    
    private SpriteRenderer spriteRenderer;
    
    AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        ogSize = transform.localScale;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
                transform.localScale = new Vector3(.4f, .4f, 1f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ogSprite != null)
            {
                spriteRenderer.sprite = ogSprite;
                transform.localScale = ogSize;
            }
        }
    }
}

