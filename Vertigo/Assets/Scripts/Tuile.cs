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


    // Start is called before the first frame update
    void Start() {
        selected = false;
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

        if (selected) {

            if (parent.endi == -1 && parent.endj == -1)
            {

                if (Acote(parent.zeroi, parent.zeroj))
                {
                    parent.endi = i;
                    parent.endj = j;
                }
            }

            selected = false;
        }
    }

    public bool Acote(int zeroi, int zeroj)
    {

        if (i == zeroi && j != zeroj)
            return true;

        if (j == zeroj && i != zeroi)
            return true;

        return false;
    }
}
