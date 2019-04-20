using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupeSon : MonoBehaviour {
    public AudioSource[] sources;
    

    private void OnCollisionExit(Collision collision) {
        foreach (var source in sources) {
            source.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        foreach (var source in sources) {
            source.enabled = false;
        }
    }
}
