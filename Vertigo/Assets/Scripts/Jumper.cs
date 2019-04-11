using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody player; 
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
            
          player.AddForce(100,0,0,ForceMode.Impulse );
            //player.AddForce(transform.up * 100);
        }
    }
}
