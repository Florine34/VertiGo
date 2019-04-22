using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class OpenTableau : MonoBehaviour {
    public Animator animTab;
    public GameObject Fusil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {

        if (other.gameObject.name.Equals("Sphere")) {
            if (animTab != null) {
                animTab.SetBool("open", true);

                if (Fusil != null && Fusil.GetComponent<VRTK_InteractableObject>() != null) {
                    Fusil.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
                }
                this.GetComponent<AudioSource>().enabled = true;
            }
        }

    }

}
