using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repop : MonoBehaviour
{
       public GameObject RespawnSphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SolPiece1")){
			gameObject.transform.position = RespawnSphere.transform.position;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        }
    }
}
