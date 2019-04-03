using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Tuile : MonoBehaviour
{
    [HideInInspector]
    public int value;
    [HideInInspector]
    public taquin parent;
    [HideInInspector]
    public int i, j;
    [HideInInspector]
    public bool selected;
    private float timer;


    // Start is called before the first frame update
    void Start() {
        selected = false;
        timer = 0.22f;
    }

    // if we detect a collision
    /*void OnCollisionEnter(Collision collision) {

        Debug.Log("Hello");
        Debug.Log(collision.gameObject.GetComponent<MyRaycast>());
        if (collision.gameObject.GetComponent<MyRaycast>() != null) {
            if (parent.begini == -1 || parent.beginj == -1)
            {
                parent.begini = i;
                parent.beginj = j;
            }
            else if (parent.begini != i || parent.beginj != j)
            {
                parent.endi = i;
                parent.endj = j;
            }
        }
    }*/

    // Update is called once per frame
    void Update() {

        if (selected && timer > 0.2f) {

            if (parent.endi == -1 && parent.endj == -1) {
                Debug.Log("Acote ? " + Acote(parent.zeroi, parent.zeroj) + "  (zeroi : "+ parent.zeroi + " zeroj : "+parent.zeroj + ")   (i : "+i+" j : "+j+")");
                if (Acote(parent.zeroi, parent.zeroj)) {
                    parent.endi = i;
                    parent.endj = j;
                }
            }

            selected = false;
            timer = 0;
        } else {
            timer += Time.deltaTime;
            selected = false;
        }
    }

    public bool Acote(int zeroi, int zeroj) {

        if (i == zeroi && j != zeroj)
            return true;

        if (j == zeroj && i != zeroi)
            return true;

        return false;
    }
}
