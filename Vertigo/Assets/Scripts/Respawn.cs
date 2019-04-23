using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Respawn : MonoBehaviour { 
    public GameObject respawn;
    public GameObject respawnFusil;

    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Dans OnTriggerEnter");
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = respawn.transform.position;

        }
        if (collision.CompareTag("Fusil"))
        {
            Debug.Log("Dans if fusil");
            collision.transform.position = respawnFusil.transform.position;
           
        }
    }
}
