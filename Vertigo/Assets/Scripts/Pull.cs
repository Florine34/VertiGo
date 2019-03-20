using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    public Rigidbody Body;

    [SerializeField]
    public Transform controller; 

    // Should be OVRInput.Controller.LTouch or OVRInput.Controller.RTouch.
    [SerializeField]
   protected OVRInput.Controller m_controller;

    [HideInInspector]
    public Vector3 prevPos;
    
    public bool canGrip; 
    // Start is called before the first frame update
    void Start()
    {
        prevPos = controller.transform.localPosition; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canGrip && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0 || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
        {
            Debug.Log("passer dans le if fixedupdate 1");
            Body.useGravity = false;
            Body.isKinematic = true; 
            Body.transform.position += prevPos- controller.transform.localPosition;
        }
        else if(canGrip && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) < 0 || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) < 0)
        {
            Debug.Log("passer dans le if fixedupdate2");
            Body.useGravity = true;
            Body.isKinematic = false;
            Body.velocity = (prevPos - controller.transform.localPosition) / Time.deltaTime;
        }
        else
        {
            //Debug.Log("passer dans le fixeupdate else");
            Body.useGravity = true;
            Body.isKinematic = false;
        }
        prevPos = controller.transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        canGrip = true; 
    }

    private void OnTriggerExit(Collider other)
    {
        canGrip = false; 
    }

    
}
