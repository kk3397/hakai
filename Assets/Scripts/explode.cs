using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    void Start()
    {
       enemy = GameObject.FindWithTag("enemy");
        transform.position = enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = enemy.transform.position;
    }
    public void DestroyAnimation()
    {
        Destroy(gameObject);
    }
}
