using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour   
{

    public GameObject target;
    public GameObject bullet;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            Fire();
            timer = 0;
        }
    }


    public void Fire()
    {
        var direction = Vector3.zero;
        Rigidbody bulletRb = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        direction = target.transform.position - transform.position;
        // bulletRb.AddRelativeForce(direction.normalized * 1000, ForceMode.Force);
        bulletRb.velocity = transform.TransformDirection(direction * 1);

    }
}
