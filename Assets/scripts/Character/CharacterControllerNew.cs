using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterControllerNew : MonoBehaviour
{
    public enum ProjectAxis { onlyX = 0, xAndY = 1 };
    public ProjectAxis projectAxis = ProjectAxis.onlyX;
    public float speed = 150;
    public float addForce = 7;
    public bool lookAtCursor;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode addForceButton = KeyCode.Space;
    public bool isFacingRight = true;
    public int score;

    public bool injump = false;
    public bool indanger=false;

   //public bool inwater = false;

    private Vector3 direction;
    private float horizontal;
    private Rigidbody2D body;
    private float rotationY;
    private bool jump;
    private Animator animatorCntrllr;


    public float respownX;
    public float respownY;
    public GameObject respownPrefab;

    //Собираем бустеры
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "booster")
        {
            Destroy(col.gameObject);
            score++;
        }
        if (col.gameObject.tag=="respown")
        {
            respownX = gameObject.transform.position.x;
            respownY = gameObject.transform.position.y;        
        }
        if (col.gameObject.tag=="enemy")
        {
            indanger = true;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            body.drag = 10;
            jump = true;
            injump = false;
        }
        if (coll.transform.tag == "Water")
        {
            indanger = true;
        }
        else
            indanger = false;

        /*else
            inwater = true;*/
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            body.drag = 0;
            jump = false;
        }
    }


    //Вывод табла на экран
   
    void Start()
    {
        animatorCntrllr = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        respownPrefab = GameObject.FindGameObjectWithTag("Player");

        if (projectAxis == ProjectAxis.xAndY)
        {
            body.gravityScale = 0;
            body.drag = 10;
        }
    }

    /*
    IEnumerator MovePlayer()
    {
        yield return new WaitForSeconds(3f);
        //respownPrefab.transform.position = new Vector3(respownX, respownY);
        Water();
        respownPrefab.transform.position = new Vector3(respownX, respownY);
        // respownPrefab.transform.position = new Vector3(respownX, respownY);
    }
    */
    void FixedUpdate()
    {

        body.AddForce(direction * body.mass * speed);
        if (Mathf.Abs(body.velocity.x) > speed / 100f)
        {
            body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
        }
        else if (indanger == true)
        {
            //MovePlayer();
            respownPrefab.transform.position = new Vector3(respownX, respownY);

        }

        if (projectAxis == ProjectAxis.xAndY)
        {
            if (Mathf.Abs(body.velocity.y) > speed / 100f)
            {
                body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed / 100f);
            }
        }
        else
        {
            if (Input.GetKey(addForceButton) && jump)
            {
                body.velocity = new Vector2(0, addForce);
                injump = true;
            }
        }
    }
   

   

    void Flip()
    {
        if (projectAxis == ProjectAxis.onlyX)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void Jump()
    {
        if(injump == true)
        {
            animatorCntrllr.Play("Jump");
        }
    }

    void Water()
    {
        if (indanger == true)
        {
            animatorCntrllr.Play("Disappear");
        }
    }

    
    void Update()
    {
        if (Input.GetKey(leftButton)) { horizontal = -1; animatorCntrllr.Play("Walk"); }
        else if (Input.GetKey(rightButton)) { horizontal = 1; animatorCntrllr.Play("Walk"); }
        else if (injump == false)
        {
            horizontal = 0;
            if (indanger==true)
            {
                Water();
            }
            else animatorCntrllr.Play("Idle");
        }

        else if (injump == true) Jump();
            if (projectAxis == ProjectAxis.onlyX)
            {
                direction = new Vector2(horizontal, 0);
            }
        
            /*else
            {
                if (Input.GetKeyDown(addForceButton)) { speed += addForce; }
                else if (Input.GetKeyUp(addForceButton)) { speed -= addForce; }

                //direction = new Vector2(horizontal, vertical);            
            }*/

            if (horizontal > 0 && !isFacingRight) Flip(); else if (horizontal < 0 && isFacingRight) Flip();
            
        }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 10, 150, 20), "score: " + score);
    }

}