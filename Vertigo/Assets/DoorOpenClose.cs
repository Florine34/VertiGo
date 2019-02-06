using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    public bool open = false;
    private float speed = 1000f;
    private Quaternion doorOpen;
    private Quaternion doorClose;
    private Vector3 relativePos;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        //relativePos = - transform.position;
        doorClose = transform.rotation;
        doorOpen = Quaternion.Euler(0, 0, 0);
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            open = true;
        }
        if (open)
        {
            Debug.Log("The door must be open");
            transform.rotation = Quaternion.RotateTowards(doorClose, doorOpen, Time.deltaTime * speed);
            //Quaternion rotation = Quaternion.LookRotation(transform.position, Vector3.);
            //transform.rotation = rotation;
        }
    }
}
