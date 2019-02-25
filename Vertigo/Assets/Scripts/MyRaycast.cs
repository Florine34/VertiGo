using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MyRaycast : MonoBehaviour
{
    public Transform depart;
    public float distance;
    private bool active;
    private bool zeroSelected;
    private int zeroi, zeroj;


    // Start is called before the first frame update
    void Start() {
        active = false;
        zeroSelected = false;
    }

    // Update is called once per frame
    void Update()  {
        int mask = 1 << 9;
        Ray center = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));    // compute the point looks at by main camera
        RaycastHit hit;
        // Quaternion inverse = new Quaternion(depart.localRotation.x, depart.localRotation.y, depart.localRotation.z, depart.localRotation.w);
        
        // create raycast only if player has clicked on mouse button
        if (Input.GetMouseButtonDown(0))  {
            active = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            if (active) {
                if (Physics.Raycast(center, out hit, distance, mask))
                {      // new Ray(depart.position, inverse * depart.forward)

                    Debug.DrawRay(center.origin, center.direction.normalized * hit.distance, new Color(1, 0.5f, 0));      // depart.position, inverse * depart.forward * hit.distance

                    if (hit.collider.gameObject.GetComponent<Tuile>() != null)
                    {
                        //Debug.Log("PROBLEME COLLISION   " + hit.collider.gameObject.GetComponent<Tuile>().i + "    " + hit.collider.gameObject.GetComponent<Tuile>().j);
                        
                        if (zeroSelected) {
                            if (Acote(hit, hit.collider.gameObject.GetComponent<Tuile>().i, hit.collider.gameObject.GetComponent<Tuile>().j)) {
                                hit.collider.gameObject.GetComponent<Tuile>().selected = true;
                                zeroSelected = false;
                            }
                        }

                        if (hit.collider.gameObject.GetComponent<Tuile>().value == 0) {
                            zeroi = hit.collider.gameObject.GetComponent<Tuile>().i;
                            zeroj = hit.collider.gameObject.GetComponent<Tuile>().j;
                            hit.collider.gameObject.GetComponent<Tuile>().selected = true;
                            zeroSelected = true;
                        }
                    }
                }
            }

            active = false;
        }
        
        if (active) {
            Debug.DrawRay(center.origin, center.direction.normalized * distance, new Color(1, 0, 0));      // depart.position, inverse * depart.forward * 1
        }
    }

    private bool Acote(RaycastHit hit, int i, int j) {

        if (hit.collider.gameObject.GetComponent<Tuile>().i == zeroi &&
            (hit.collider.gameObject.GetComponent<Tuile>().j == zeroj + 1 ||
            hit.collider.gameObject.GetComponent<Tuile>().j == zeroj - 1))
        {

            return true;
        }

        if (hit.collider.gameObject.GetComponent<Tuile>().j == zeroj &&
            (hit.collider.gameObject.GetComponent<Tuile>().i == zeroi - 1 ||
            hit.collider.gameObject.GetComponent<Tuile>().i == zeroi + 1))
        {

            return true;
        }

        return false;
    }
}
