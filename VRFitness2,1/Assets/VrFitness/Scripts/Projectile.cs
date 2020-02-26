using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{  public GameObject explosion;
    public string tagName;
   
    /*
    private void OnTriggerEnter(Collider other)
    {
       
            if (other.gameObject.tag.Equals(tagName))
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                GameObject clone = Instantiate(explosion, transform.position, transform.rotation);

            }
        

    }
    */

    private void OnTriggerStay(Collider other)
    {
      
            if (other.gameObject.tag.Equals(tagName))
            {
            Debug.Log("hit");
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                GameObject clone = Instantiate(explosion, other.transform.position, transform.rotation);

            }
        
    }

}
