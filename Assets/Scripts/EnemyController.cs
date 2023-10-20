using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    private float distance;
    public float rotSpeed;
    private Rigidbody2D rb;
    private Transform player;
   
    public GameObject explode;
    private AudioManager manager;
    private GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        manager=GetComponent<AudioManager>();

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
    void Update()

    {
         player = GameObject.FindWithTag("Player").transform;

        //distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform.position;
        //direction.Normalize();
        //RotateTowardsPlayer(player);
        Vector3 follow =  Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        transform.position=follow;
        RotateTowardsPlayer(player);



    }
    //move towards player
    private void FixedUpdate()
    {
         

            
            
    

    }
    //rotate towards player
    private void RotateTowardsPlayer(Transform player)
    {
        var offset = 90f;
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        float ang = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (ang - offset));


    }

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.CompareTag("Player")))
        {
            
            FindAnyObjectByType<AudioManager>().Play("Explosion");
            Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gameController.LiveCount();
        }

        if ((other.gameObject.CompareTag("bullet")))
        {
            Instantiate(explode, transform.position, Quaternion.identity);
            
            FindAnyObjectByType<AudioManager>().Play("Explosion");
        }



    }
    
}
