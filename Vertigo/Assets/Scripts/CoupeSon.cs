using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CoupeSon : MonoBehaviour {
    public AudioSource[] sources;

    private void OnTriggerEnter(Collider other) {
        VRTK_BodyPhysics body = other.gameObject.GetComponent<VRTK_BodyPhysics>();
        if (body)
        {
            foreach (var source in sources){
                Debug.Log("foreach");
                source.enabled = false;
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        VRTK_BodyPhysics body = other.gameObject.GetComponent<VRTK_BodyPhysics>();
        if (body)
        {
            foreach (var source in sources)
            {
                Debug.Log("foreach exit");
                source.enabled = true;
            }
        }
    }
}
