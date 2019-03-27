using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Fireball : MonoBehaviour {
    public GameObject ball;
    public Transform depart;
    private List<GameObject> balls;
    private float timing = 0.0f;

    // Start is called before the first frame update
    void Start() {
        balls = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        GameObject b;
        Vector3 dir = transform.forward;   //-(transform.rotation * depart.right);   // (Quaternion.Euler(new Vector3(0, -90, 0)) * transform.rotation * transform.forward).normalized;
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0 && timing > 1) {
            timing = 0;
            b = Instantiate(ball);
            b.transform.position = depart.position/* + dir*/;  /*new Vector3(r.origin.x + r.direction.normalized.x/3, r.origin.y + r.direction.normalized.y/3, r.origin.z + r.direction.normalized.z/3)*/
            b.GetComponent<Rigidbody>().AddForce(dir * 40, ForceMode.Impulse);

            balls.Add(b);
            Debug.Log("depart : " + depart.position);
        }

        timing += Time.deltaTime;
    }
}
