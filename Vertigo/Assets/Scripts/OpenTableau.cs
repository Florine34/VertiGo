using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTableau : MonoBehaviour {
    public Animator animTab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnColliderEnter(Collider other){
        //Animator animTab;

        if (other.CompareTag("Boule")) {
            if (animTab != null) {
                animTab.SetBool("open", true);

                Debug.LogError("Boule");
            }
        }

    }

}
