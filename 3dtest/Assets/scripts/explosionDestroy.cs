using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyExplosion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroyExplosion()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        //delete explosion
        Destroy(gameObject);
    }
}
