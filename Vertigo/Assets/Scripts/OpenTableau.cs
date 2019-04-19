using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTableau : MonoBehaviour {
    public Animator animTab;
    public GameObject Fusil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnColliderEnter(Collider other){

        if (other.name.Equals("Sphere")) {
            if (animTab != null) {
                animTab.SetBool("open", true);

                Debug.LogError("Boule");

                if (Fusil != null && Fusil.GetComponent<Rigidbody>() != null) {
                    Fusil.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }
            }
        }

    }

}
