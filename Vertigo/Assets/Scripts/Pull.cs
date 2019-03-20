using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    //public Rigidbody Body;
    
    [SerializeField]
    public Transform m_gripTransform = null;

    // Should be OVRInput.Controller.LTouch or OVRInput.Controller.RTouch.
    [SerializeField]
    protected OVRInput.Controller m_controller;

    [HideInInspector]
    public Vector3 prevPos;

    [HideInInspector]
    public bool canGrip; 
    // Start is called before the first frame update
    void Start()
    {
        prevPos = m_gripTransform.transform.localPosition; 
    }

    /* Update is called once per frame
    void FixedUpdate()
    {

        if (canGrip && OVRInput.GetDown(OVRInput.Button.Two))
        {
            Body.useGravity = false;
            Body.isKinematic = true; 
            Body.transform.position += prevPos- m_gripTransform.transform.localPosition;
        }
        else if(canGrip && OVRInput.GetUp(OVRInput.Button.Two)){
            Body.useGravity = true;
            Body.isKinematic = false;
            Body.velocity = (prevPos - m_gripTransform.transform.localPosition) / Time.deltaTime;
        }
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;
        }
        prevPos = m_gripTransform.transform.localPosition;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        canGrip = true; 
    }

    private void OnTriggerExit(Collider other)
    {
        canGrip = false; 
    }
}
