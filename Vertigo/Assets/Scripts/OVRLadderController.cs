using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
    public class OVRLadderController : MonoBehaviour
{
    public float speed = 5.0f;



    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    public void _init()
    {
    }
    void Start()
    {

        controller = gameObject.GetComponent<CharacterController>();
    }
    void Update()
    {


        moveDirection = new Vector3(0, Input.GetAxis("Vertical"), 0);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        controller.Move(moveDirection * Time.deltaTime);
    }

   
}