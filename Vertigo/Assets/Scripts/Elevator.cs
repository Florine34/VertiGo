using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OVRPlayerController")
        {
           transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, transform.position.z);
           if(transform.position.y == 20)
           {
                moveSpeed = 0; 
           }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "OVRPlayerController")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime, transform.position.z);
        }
        if(transform.position.y == 14)
        {
            moveSpeed = 0;
        }
    }
}
