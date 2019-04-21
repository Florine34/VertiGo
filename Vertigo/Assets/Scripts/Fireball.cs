using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fireball : MonoBehaviour {
    public ChangeColorPaint color;
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
            b.GetComponent<Rigidbody>().AddForce(dir.normalized * 40, ForceMode.Impulse);
            SetColor(b);
            if (GetComponent<AudioSource>() != null)
                GetComponent<AudioSource>().PlayOneShot(flareBurningSound);
        }

        timing += Time.deltaTime;
    }

    void SetColor(GameObject b) {


        switch (color.GetCounter()) {
            case 0: // Bleu 
                //Debug.LogError("Counter : " + color.GetCounter());
                b.GetComponent<flarebullet>().SetColor(Color.cyan);
                break;
            case 1: // Jaune
                //Debug.LogError("Counter : " + color.GetCounter());
                b.GetComponent<flarebullet>().SetColor(Color.yellow);
                break;
            case 2: // Magenta
                //Debug.LogError("Counter : " + color.GetCounter());
                b.GetComponent<flarebullet>().SetColor(Color.magenta);
                break;
            case 3: // Rouge
                //Debug.LogError("Counter : " + color.GetCounter());
                b.GetComponent<flarebullet>().SetColor(Color.red);
                break;
            case 4: // Vert 
                //Debug.LogError("Counter : " + color.GetCounter());
                b.GetComponent<flarebullet>().SetColor(Color.green);
                break;
        }
    }
}
