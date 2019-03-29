using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloche : MonoBehaviour
{
    public GameObject cloche;
    public GameObject cubeRouge; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Sphere")
        {
            cloche.SetActive(false);
            cubeRouge.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; 
        }
    }
}
