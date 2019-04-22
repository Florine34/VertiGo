using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CoupeSon : MonoBehaviour {
    public AudioSource[] sources;

    private void OnTriggerEnter(Collider other) {
        VRTK_BodyPhysics body = other.gameObject.GetComponent<VRTK_BodyPhysics>();
        if (body != null) {
            foreach (var source in sources){
                source.enabled = false;
            }

            if (GetComponent<AudioSource>() != null)
                GetComponent<AudioSource>().enabled = true;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        VRTK_BodyPhysics body = other.gameObject.GetComponent<VRTK_BodyPhysics>();
        if (body != null) {
            foreach (var source in sources) {
                source.enabled = true;
            }

            if (GetComponent<AudioSource>() != null)
                GetComponent<AudioSource>().enabled = false;
        }
    }
}
