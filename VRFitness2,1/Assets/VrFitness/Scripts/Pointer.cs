using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Pointer : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    public float Distance = 2.0f;
    public GameObject mDot;
    public GameObject turret;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;



    private LineRenderer lineRenderer = null;
    private SteamVR_Behaviour_Pose pose;


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
    }
   
    // Update is called once per frame
    void Update()
    {
        UpdateLine();


       

        turret.GetComponent<TurretController>().target1 = mDot;


        if (fireAction.GetStateDown(pose.inputSource))
        {
            Debug.Log("fire");
            Fire();
        }
    }


    private void UpdateLine()
    {
        float targetLength = Distance;

        RaycastHit hit = CreateRayCast(targetLength);      
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        mDot.transform.position = endPosition;
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }



    private RaycastHit CreateRayCast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, Distance);

        return hit;
    }


    public void Fire()
    {
        Rigidbody bulletRb = Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.velocity = bulletSpawnPoint.transform.forward * 50.0f;

    }
}
