using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMoveScript : MonoBehaviour
{
    public GameObject jelly;
    public GameObject player;
    public bool PlayerOn;
    public int direction = 1;
    public float speed = 0.05f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.right * speed * direction;
      /*  if (PlayerOn==true)
            player.transform.position += Vector3.right * speed * direction;*/
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Cменить направление движения
        if (col.gameObject.tag == "change direction")
        {
            direction = (-1) * direction;
        }
    }

    /*void OnCollision(Collision2D col)
    {
        if (col.gameObject.tag=="Player")
        {
            PlayerOn = true;
        }
    }*/
}


