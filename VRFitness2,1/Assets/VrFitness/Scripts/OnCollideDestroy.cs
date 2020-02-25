using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }


    private void OnCollisionStay(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
