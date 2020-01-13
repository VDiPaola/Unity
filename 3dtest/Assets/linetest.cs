using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linetest : MonoBehaviour
{
    LineRenderer line;

    public Transform object1;
    public Transform object2;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, object1.position);
        line.SetPosition(1, object2.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
