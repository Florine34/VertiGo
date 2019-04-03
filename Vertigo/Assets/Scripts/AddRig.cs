using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Rigidbody rig;
        int n = transform.childCount;

        for (int i = 0; i < n; i++) {
            rig = transform.GetChild(i).gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            rig.isKinematic = true;
            rig.useGravity = false;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
