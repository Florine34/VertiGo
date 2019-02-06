using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    public float speed = 1f;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       // cam.transform.Translate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"),0);
        transform.Translate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        transform.Translate(cam.transform.forward * Input.GetAxis("Vertical"));
        
        if (Input.GetMouseButton(0) == true)
        {
            Debug.Log("Pressed primary button.");

            transform.Rotate(0, 1 * speed, 0);
        }
        else if(Input.GetMouseButton(1) == true)
        {
            transform.Rotate(0, -1 * speed,0);
        }
    }
}
