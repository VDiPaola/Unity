using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class probe : MonoBehaviour
{

    Transform currentT;
    LineRenderer currentLR;
    public Rigidbody playerRB;

    public Transform playerT;

    static bool isHit = false;

    bool attached = false;
    bool x = true;

    public GameObject Wire;

    // Start is called before the first frame update
    void Start()
    {
        currentT = GetComponent<Transform>();
        currentLR = GetComponent<LineRenderer>();
        currentLR.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //line renderer to player
        if (!attached)
        {
            currentLR.SetPosition(0, currentT.position);
            currentLR.SetPosition(1, playerT.position);
        }
        else
        {
            if (x)
            {
                x = false;
                //disable rope
                currentLR.enabled = false;
                //create a rectangle in place of the rope and add joints to the probe and player
                Vector3 P1 = currentT.position;
                Vector3 P2 = playerT.position;

                float length = (P1 - P2).magnitude;

                Vector3 centerPoint = (P1 + P2) / 2;

                GameObject wire = Instantiate(Wire, gameObject.GetComponent<Transform>());
                

                wire.GetComponent<Transform>().position = centerPoint;
                wire.GetComponent<Transform>().LookAt(P1);
                wire.GetComponent<Transform>().localScale = new Vector3(1,1,length*2);
                wire.GetComponent<Transform>().SetParent(currentT);

                wire.AddComponent<Rigidbody>();
                wire.GetComponent<Rigidbody>().useGravity = false;

                wire.AddComponent<FixedJoint>();
                wire.GetComponent<FixedJoint>().connectedBody = playerRB;
                gameObject.AddComponent<FixedJoint>();
                gameObject.GetComponent<FixedJoint>().connectedBody = wire.GetComponent<Rigidbody>();


                wire.SetActive(true);


            }
        }

        if (Input.GetKey("z"))
        {
            attached = true;
        }
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        isHit = true;
        //create fixed joint component
        gameObject.AddComponent<FixedJoint>();
        gameObject.GetComponent<FixedJoint>().connectedBody = collision.collider.GetComponent<Rigidbody>();
        //joint with what it collides with

    }

    private void OnDestroy()
    {
        isHit = false;
    }


}
