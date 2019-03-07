using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject ball;
    private List<GameObject> balls;

    // Start is called before the first frame update
    void Start()
    {
        balls = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject b;
        Camera cam = Camera.main;
        Ray r = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Input.GetMouseButtonDown(0)) {
            b = Instantiate(ball);
            b.transform.position = new Vector3(r.origin.x + r.direction.normalized.x/3, r.origin.y + r.direction.normalized.y/3, r.origin.z + r.direction.normalized.z/3);
            b.GetComponent<Rigidbody>().AddForce(r.direction.normalized * 20, ForceMode.Impulse);

            balls.Add(b);
        }
    }
}
