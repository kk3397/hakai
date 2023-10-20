using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed  = 10f;
    private float lifetime = 3f;
    private Rigidbody2D rb;

    public int scoreValue;
    
   
    
    private GameController gameController;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
        
       

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find GameController script");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
       
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
           
            Destroy(other.gameObject);
            Destroy(gameObject);
            
            FindAnyObjectByType<AudioManager>().Play("Explosion");
            gameController.AddScore(scoreValue);


        }
    }
    

}
