using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlls : MonoBehaviour
{
    //vars
    public Rigidbody2D playerRB;
    public Transform playerT;
    public Camera camera;

    bool jumping = false;
    

    // Start is called before the first frame update


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerT = GetComponent<Transform>();
        camera = GetComponent<Camera>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if ( Input.GetKeyDown("space") && !jumping)
        {
            //player jumps towards mouse position
            jumping = true;
            Vector3 td = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerT.position;
            //float angle = Vector3.Angle(td, playerT.forward);
            playerRB.AddForce(td,ForceMode2D.Impulse);

            /*
             Vector3 targetDir = target.position - transform.position;
             float angle = Vector3.Angle(targetDir, transform.forward);
             */
        }
        else if (Input.GetKey("escape"))
        {
            Application.Quit();
        }else if (Input.GetKey("r"))
        {
            Application.LoadLevel(Application.loadedLevel);
           
        }else if (Input.GetKey("d"))
        {
            //playerRB.velocity = new Vector2(10, playerRB.velocity.y);

            //playerRB.AddRelativeForce(new Vector2(1*50, 0), ForceMode2D.Force);
        }
        else if (Input.GetKey("a"))
        {
            //playerRB.velocity = new Vector2(-10, playerRB.velocity.y);

            //playerRB.AddRelativeForce(new Vector2(-1*50, 0), ForceMode2D.Force);
        }


    }
    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        jumping = false;
    }
}
