using UnityEngine;

public class buttonManager : MonoBehaviour
{
    [SerializeField] Color ogColor; 
    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ogColor = spriteRenderer.color;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.color = new Color(0.2f,0.4f,0.1f,1);
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //spriteRenderer.color = ogColor;
        }
    }

    void Update()
    {
        
    }
}