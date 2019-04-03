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
        Vector3 dir = -transform.right;

        if ((OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0) && timing > 1) {
            timing = 0;
            b = Instantiate(ball, depart.position, depart.rotation);
            b.GetComponent<Rigidbody>().AddForce(dir.normalized * 40, ForceMode.Impulse);

            balls.Add(b);
        }

        timing += Time.deltaTime;
    }
}
