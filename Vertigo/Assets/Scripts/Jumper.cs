using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Jumper : MonoBehaviour
{
    // Start is called before the first frame update
    private bool active = true;
    
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        VRTK_BodyPhysics body = other.gameObject.GetComponent<VRTK_BodyPhysics>();

        if (active && body != null) {
            body.Jump();
        }

        active = !active;

        /*if (other.tag == "OVRPlayerController") {
            player = other.gameObject.GetComponent<Rigidbody>();
            player.AddForce(100, 0, 0, ForceMode.Impulse);
            //player.AddForce(transform.up * 100);
        }*/
    }
}
