using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupeSon : MonoBehaviour {
    public AudioSource[] sources;

    private void OnTriggerEnter(Collider other) {
        foreach (var source in sources)
        {
            source.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        foreach (var source in sources)
        {
            source.enabled = false;
        }
    }
}
