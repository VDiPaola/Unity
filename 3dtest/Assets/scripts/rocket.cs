using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rocket : MonoBehaviour
{
    public GameObject explosion;
    public GameObject debris;
    public Transform debrisParent;
    public Text points;

    Transform currentT;
    

    // Start is called before the first frame update
    void Start()
    {
        currentT = GetComponent<Transform>();
        StartCoroutine(deleteRocket());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        /*
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "MyGameObjectName")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
        }

        */

        //boom
        //create explosion
        GameObject explosionClone = Instantiate(explosion, currentT.position, currentT.rotation);
        explosionClone.SetActive(true);

        //add debris
        GameObject debrisClone = Instantiate(debris, currentT.position, currentT.rotation, debrisParent);
        debrisClone.SetActive(true);
        debrisClone.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10,10), Random.Range(-10, 10), Random.Range(-10, 10));
        GameObject debrisClone2 = Instantiate(debris, currentT.position, currentT.rotation, debrisParent);
        debrisClone2.SetActive(true);
        debrisClone2.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));

        //add point
        controls.points += 1;
        //update UI
        points.text = "" + controls.points;

        //delete rocket
        Destroy(gameObject);

    }

    IEnumerator deleteRocket()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(4);

        //delete rocket
        Destroy(gameObject);
    }
}
