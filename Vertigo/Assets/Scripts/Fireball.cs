using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fireball : MonoBehaviour {
    public AudioClip flareBurningSound;
    public GameObject ball;
    public Transform depart;
    private float timing = 0.0f;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        GameObject b;
        Vector3 dir = -transform.right;

        if ((OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0) && timing > 1) {
            timing = 0;
            b = Instantiate(ball, depart.position, depart.rotation);
            b.GetComponent<flarebullet>().parent = GetComponent<CheckColor>();
            b.GetComponent<Rigidbody>().AddForce(dir.normalized * 60, ForceMode.Impulse);

            if (GetComponent<AudioSource>() != null)
                GetComponent<AudioSource>().PlayOneShot(flareBurningSound);
        }

        timing += Time.deltaTime;
    }
}
