using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;




public class Rise : MonoBehaviour {
    public Animator[] plaques; 

    
    private void OnTriggerEnter(Collider other) {

        if (other.GetComponent<VRTK_BodyPhysics>() != null) {
            transform.parent.GetComponent<Animator>().SetBool("rise", true);
        }
    }

    private void OnTriggerExit(Collider other) {

        if (other.GetComponent<VRTK_BodyPhysics>() != null) {
            transform.parent.GetComponent<Animator>().SetBool("rise", false);
        }
    }

    public void EnabledTrap() {
        foreach (var plaque in plaques) {
            plaque.SetBool("ouvert", true);
        }
    }

    public void DisableTrap() {
        foreach (var plaque in plaques) {
            plaque.SetBool("ouvert", false);
        }
    }
}
