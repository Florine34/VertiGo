﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripManager : MonoBehaviour
{

    public Rigidbody Body;
    public OVRTracker controller; 
    public Pull left;
    public Pull right;

    // Update is called once per frame
    void FixedUpdate()
    {
        var lDevice = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        var rDevice = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.RTouch);

        bool isGripped = left.canGrip || right.canGrip;

        if (isGripped)
        {
            if (left.canGrip && lDevice > 0 )
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.transform.position += left.prevPos - left.transform.localPosition;
            }
            else if (left.canGrip && lDevice < 0)
            {
                Body.useGravity = true;
                Body.isKinematic = false;
                Body.velocity = (left.prevPos - left.transform.localPosition) / Time.deltaTime;
            }

            if (right.canGrip && rDevice > 0)
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.transform.position += right.prevPos - right.transform.localPosition;
            }
            else if (right.canGrip && rDevice < 0)
            {
                Body.useGravity = true;
                Body.isKinematic = false;
                Body.velocity = (right.prevPos - right.transform.localPosition) / Time.deltaTime;
            }

        }
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;
        }

     

        left.prevPos = left.transform.localPosition;
        right.prevPos = right.transform.localPosition;
    }
}
