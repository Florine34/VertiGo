using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTouch : MonoBehaviour {
    public Transform depart;
    public int distance = 2;
    private bool active;

    // Start is called before the first frame update
    void Start() {
        active = false;    
    }

    // Update is called once per frame
    void Update() {
        int mask = 1 << 9;
        RaycastHit hit;
        Ray direction = new Ray();
        direction.origin = depart.position;
        direction.direction = depart.forward;

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0) {
            GetComponent<LineRenderer>().enabled = true;
            active = true;
        } else {
            GetComponent<LineRenderer>().enabled = false;

            // detect collision with raycast
            if (active) {
                if (Physics.Raycast(direction, out hit, distance, mask)) {      // new Ray(depart.position, inverse * depart.forward)
                    Debug.DrawRay(direction.origin, direction.direction.normalized * hit.distance, new Color(1, 0.5f, 0));      // depart.position, inverse * depart.forward * hit.distance

                    if (hit.collider.gameObject.GetComponent<Tuile>() != null)
                        hit.collider.gameObject.GetComponent<Tuile>().selected = true;
                }
            }

            active = false;
        }

        if (active) {
            Debug.DrawRay(direction.origin, direction.direction.normalized * distance, new Color(1, 0, 0));      // depart.position, inverse * depart.forward * 1
        }
    }
}
