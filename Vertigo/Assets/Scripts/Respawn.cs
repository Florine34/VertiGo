using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Respawn : MonoBehaviour { 
    public GameObject respawn;
    public GameObject perso;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.position = respawn.transform.position;

        }
        else if (collision.transform.CompareTag("Fusil"))
        {
            collision.transform.position = perso.transform.position;
        }
    }
}
