using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float maxSpeed = 5f;
    public float rotSpeed = 180f;
    public float fireRate;
    private float nextFire;
    public Transform bulletPos;

    float boundary = 1.0f;
    public GameObject bullet;
    public Animator anim;

    private GameController gameController;


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
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
        //rotate
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;
        // move player
        Vector3 pos = transform.position;
        Vector3 vel = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * vel;
        //height boundary
        if (pos.y + boundary > Camera.main.orthographicSize)
            pos.y = Camera.main.orthographicSize - boundary;
        if (pos.y - boundary < -Camera.main.orthographicSize)
            pos.y = -Camera.main.orthographicSize + boundary;
        //get Screen Dimensions
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float screenWidthOrtho = Camera.main.orthographicSize * screenRatio;
        //width boundary
        if (pos.x + boundary > screenWidthOrtho)
            pos.x = screenWidthOrtho - boundary;
        if (pos.x - boundary < -screenWidthOrtho)
            pos.x = -screenWidthOrtho + boundary;

        transform.position = pos;
        if (Input.GetKeyDown("space"))
        {

            fire();

        }
        if (gameController.isDead == true)
        {
            Destroy(gameObject);
            gameController.endGame();
        }
    }
    void fire()
    {
        Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        FindAnyObjectByType<AudioManager>().Play("Lazer");
    }
   

}
