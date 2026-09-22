using System;
using UnityEngine;

public class greenBumper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Sprite newSprite; 
    [SerializeField] private Sprite ogSprite;

    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
                
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
                
            }
        }
    }
}