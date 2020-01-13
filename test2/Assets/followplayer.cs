using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class followplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Transform camera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.position = new Vector3(target.position.x, target.position.y,-30);
    }
}
