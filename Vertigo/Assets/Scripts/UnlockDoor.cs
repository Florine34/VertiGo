using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour { 
    // Lights 
    public GameObject lightR;
    public GameObject lightV;
    public GameObject lightB;

    public OpenDoor door; 


    // Start is called before the first frame update
    void Start() {
        
    }


    // Update is called once per frame
    void Update() {
        
    }


    void OnCollisionEnter(Collision other) {


        if (gameObject.name == "SupportR" && other.gameObject.name == "CubeRouge") {
            lightR.GetComponent<Renderer>().material.color = Color.green;
            door.OpenTheDoor();
        }

        if (gameObject.name == "SupportV" && other.gameObject.name == "CubeVert") {
            lightV.GetComponent<Renderer>().material.color = Color.green;
            door.OpenTheDoor(); 
        }

        if (gameObject.name == "SupportB" && other.gameObject.name == "CubeBleu") {
            lightB.GetComponent<Renderer>().material.color = Color.green;
            door.OpenTheDoor();
        }

    }


    void OnCollisionExit(Collision other) {
        if (gameObject.name == "SupportR" && other.gameObject.name == "CubeRouge") {
            lightR.GetComponent<Renderer>().material.color = Color.white;
            door.CloseTheDoor();
        }
        
        if (gameObject.name == "SupportV" && other.gameObject.name == "CubeVert") {
            lightV.GetComponent<Renderer>().material.color = Color.white;
            door.CloseTheDoor();
        }

        if (gameObject.name == "SupportB" && other.gameObject.name == "CubeBleu") {
            lightB.GetComponent<Renderer>().material.color = Color.white;
            door.CloseTheDoor();
        }
    }
}
