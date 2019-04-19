using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;




public class OpenCloche : MonoBehaviour {
    public GameObject cloche;
    public GameObject cubeRouge; 


    // Start is called before the first frame update
    void Start() {
        
    }


    // Update is called once per frame
    void Update() {
        
    }


    void OnCollisionEnter(Collision other) {

        if(other.gameObject.name.Equals("Sphere")) {
            cloche.SetActive(false);

            if (cubeRouge != null && cubeRouge.GetComponent<VRTK_InteractableObject>() != null) {
                cubeRouge.GetComponent<VRTK_InteractableObject>().enabled = true;
            } 
        }
    }
}
