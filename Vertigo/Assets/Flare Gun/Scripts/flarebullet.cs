using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Es.InkPainter.Sample;


public class flarebullet : MonoBehaviour {
    private ChangeColorPaint color;
    private CollisionPainter painter;
    private float timer = 0f;
    [HideInInspector]
    public CheckColor parent;


    // Use this for initialization
    void Start () {
        painter = GetComponent<CollisionPainter>();
        painter.brush.Color = new Color(0, 0, 100);
    }

    void Update() {
        if (timer > 10) {
            Destroy(this);
        }

        timer += Time.deltaTime;

        //SetColor();
    }

    private void OnColliderEnter(Collider other) {

       if (other.gameObject.tag == "SphereAColorier") {
            if (parent != null) parent.ManageColor(other.gameObject.name, painter.brush.Color);
       }

    }

    void SetColor() {
        switch (color.GetCounter()) {
            case 0: // Bleu clair
                painter.brush.Color = Color.cyan;
                break;
            case 1: // Jaune
                painter.brush.Color = Color.yellow;
                break;
            case 2: // Magenta
                painter.brush.Color = Color.magenta;
                break;
            case 3: // Rouge
                painter.brush.Color = Color.red;
                break;
            case 4: // Vert 
                painter.brush.Color = Color.green;
                break;
            case 5: // Bleu Foncé
                painter.brush.Color = Color.blue;
                break;

        }
    }
}
