using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Es.InkPainter.Sample;


public class flarebullet : MonoBehaviour {
    private CollisionPainter painter;
    private float timer = 0f;
    [HideInInspector]
    public CheckColor parent;


    // Use this for initialization
    void Start () {
        timer = 0f;
        painter = GetComponent<CollisionPainter>();
        painter.brush.Color = new Color(0, 0, 100);
    }

    void Update() {
        //Debug.Log("Timer : " + timer);

        if (timer > 2) {
            Destroy(this);
        }

        timer += Time.deltaTime;
    }

    private void OnColliderEnter(Collider other) {

       if (other.gameObject.tag == "SphereAColorier") {
            if (parent != null) parent.ManageColor(other.gameObject.name, painter.brush.Color);
       }

    }

    public void SetColor(Color color) {
        GetComponent<CollisionPainter>().brush.Color = color;
        GetComponent<MeshRenderer>().material.color = color;
    }
}
