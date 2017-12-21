using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMoveCsript : MonoBehaviour
{
    public GameObject jelly;
    public int direction = 1;
    public float speed = 0.05f;
    public GameObject player;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.up * speed * direction;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Собираем бустеры
        if (col.gameObject.tag == "change direction")
        {
            direction = (-1) * direction;
        }
    }
    
}