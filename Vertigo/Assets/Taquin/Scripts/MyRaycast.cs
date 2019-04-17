using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;



public class MyRaycast : MonoBehaviour
{
    //public Transform depart;
    public VRTK_InteractableObject linkedObject;
    //public float distance;
    //private bool active;


    protected virtual void OnEnable() {
        Debug.Log("Hello dans  OnEnable ");
        linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

        if (linkedObject != null) {
            linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            linkedObject.InteractableObjectUnused += InteractableObjectUnused;
        }
    }

    protected virtual void OnDisable() {
        if (linkedObject != null) {
            linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            linkedObject.InteractableObjectUnused -= InteractableObjectUnused;
        }
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e) {
        Debug.Log("Hello dans InteractableObjectUsed");
        Tuile t = GetComponent<Tuile>();
        if (t != null)
            Debug.Log("Hello " + name + " (" + t.i + " " + t.j + ") ");
        if (t != null)
            t.selected = true;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e) {
        Debug.Log("Hello dans desac InteractableObjectUsed");
    }

    // Start is called before the first frame update
    /*void Start() {
        active = false;
    }*

    // Update is called once per frame
    /*void Update()  {*/
    /*int mask = 1 << 9;
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
                    hit.collider.gameObject.GetComponent<Tuile>().selected = true;
            }
        }

        active = false;
    }

    if (active) {
        Debug.DrawRay(center.origin, center.direction.normalized * distance, new Color(1, 0, 0));      // depart.position, inverse * depart.forward * 1
    }*/
    // }


    public void OnSelected(Transform tuile) {
        Tuile t = tuile.gameObject.GetComponent<Tuile>();
        if (t != null)
            Debug.Log("Hello " + tuile.gameObject.name + " (" + t.i + " " + t.j+") ");
        if (t != null)
            t.selected = true;
    }
    
}
