using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // Start is called before the first frame update
    public OVRPlayerController player;
    private bool Jump;
  
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OVRPlayerController" && Jump == false)
        {
            player.Jump();
            player.GravityModifier = 0.1f;
            Jump = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Jump = false;
        //player.GravityModifier = 1f;
    }
}
