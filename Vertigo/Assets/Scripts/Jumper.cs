using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Jumper : MonoBehaviour {
    public int force;
    public Animator[] plaques;
    private bool active = true;
    


    void Start() {
        active = true;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        VRTK_BodyPhysics body = other.gameObject.GetComponent<VRTK_BodyPhysics>();

        if (active && body != null) {
            body.Jump(force);

            foreach (var plaque in plaques) {
                plaque.SetBool("ouvert", true);
            }

        } else {
            foreach (var plaque in plaques) {
                plaque.SetBool("ouvert", false);
            }
        }

        active = !active;
    }
}
