using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class taquin : MonoBehaviour
{
    public int n;
    public float speed;
    public GameObject modele;
    public Material highlight;
    public Material baseMaterial;
    public Texture2D[] images;
    private GameObject[][] tuiles;
    private bool locked;
    [HideInInspector]
    public int begini, beginj;
    [HideInInspector]
    public int endi, endj;



    // Start is called before the first frame update
    void Start() {
        begini = -1; beginj = -1;
        endi = -1; endj = -1;

        // the taquin game must have a min dimension of 3 otherwise not interesting
        if (n < 3)
            n = 3;

        locked = false;
        float border = 0.01f;
        float w = transform.GetChild(0).localScale.x / n - border, h = transform.GetChild(0).localScale.y / n - border;
        float x = transform.GetChild(0).localPosition.x - transform.GetChild(0).localScale.x / 2f + w / 2f + border / 2f/* - border*/;  /* -  ;*/
        float y = transform.GetChild(0).localPosition.y + transform.GetChild(0).localScale.y / 2f - h / 2f - border / 2f/* + border*/;  /* +  ;*/
        int[] numbers = GenNumberSequence(n*n);

        // init tiles
        if (modele != null) {
            tuiles = new GameObject[n][];

            for (int i = 0; i < n; i ++) {
                tuiles[i] = new GameObject[n];
                for (int j = 0; j < n; j ++) {
                    // create the new tile from left to right
                    tuiles[i][j] = Instantiate(modele);
                    tuiles[i][j].transform.SetParent(transform.GetChild(1));
                    tuiles[i][j].transform.localPosition = new Vector3(x + j*(w+border), y - i*(h + border), -0.015f);
                    tuiles[i][j].transform.localScale = new Vector3(w, h, border);
                    tuiles[i][j].layer = 9;
                    // assign a number different between each tiles
                    tuiles[i][j].GetComponent<Tuile>().value = numbers[i*n+j];
                    tuiles[i][j].transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = numbers[i*n+j].ToString();
                    tuiles[i][j].GetComponent<MeshRenderer>().material.mainTexture = images[j*n+i];
                    tuiles[i][j].GetComponent<Tuile>().i = i;
                    tuiles[i][j].GetComponent<Tuile>().j = j;
                    tuiles[i][j].GetComponent<Tuile>().parent = this;
                    if (tuiles[i][j].GetComponent<Tuile>().value == 0) {
                        tuiles[i][j].GetComponent<MeshRenderer>().enabled = false;
                        tuiles[i][j].transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }

        }
    }

    // Update is called once per frame
    void Update() {

        if (!locked)
        {
            if (begini > -1 && beginj > -1) {
                if (begini - 1 >= 0)
                    tuiles[begini - 1][beginj].GetComponent<Renderer>().materials = new Material[2] {tuiles[begini - 1][beginj].GetComponent<Renderer>().material, highlight};
                if (beginj-1 >= 0)
                    tuiles[begini][beginj-1].GetComponent<Renderer>().materials = new Material[2] {tuiles[begini][beginj-1].GetComponent<Renderer>().material, highlight};
                if (begini+1 < n)
                    tuiles[begini+1][beginj].GetComponent<Renderer>().materials = new Material[2] {tuiles[begini+1][beginj].GetComponent<Renderer>().material, highlight};
                if (beginj+1 < n)
                    tuiles[begini][beginj+1].GetComponent<Renderer>().materials = new Material[2] {tuiles[begini][beginj+1].GetComponent<Renderer>().material, highlight};
            }

            if (endi > -1 && endj > -1) {
                if (begini - 1 >= 0)
                    tuiles[begini - 1][beginj].GetComponent<Renderer>().materials = new Material[1] {tuiles[begini - 1][beginj].GetComponent<Renderer>().material};
                if (beginj - 1 >= 0)
                    tuiles[begini][beginj - 1].GetComponent<Renderer>().materials = new Material[1] {tuiles[begini][beginj-1].GetComponent<Renderer>().material};
                if (begini + 1 < n)
                    tuiles[begini + 1][beginj].GetComponent<Renderer>().materials = new Material[1] {tuiles[begini + 1][beginj].GetComponent<Renderer>().material};
                if (beginj + 1 < n)
                    tuiles[begini][beginj + 1].GetComponent<Renderer>().materials = new Material[1] {tuiles[begini][beginj+1].GetComponent<Renderer>().material};
            }

            if (begini > -1 && beginj > -1 && endi > -1 && endj > -1)
            {
                Animation anim1 = tuiles[begini][beginj].GetComponent<Animation>();
                Animation anim2 = tuiles[endi][endj].GetComponent<Animation>();
                AnimationCurve curvex, curvey, curvez;
                float x1, y1, z1, x2, y2, z2;
                AnimationClip newAnim;
                GameObject exch = tuiles[begini][beginj];

                if (!anim1.isPlaying && !anim2.isPlaying)
                {
                    x1 = tuiles[begini][beginj].transform.localPosition.x;
                    y1 = tuiles[begini][beginj].transform.localPosition.y;
                    z1 = tuiles[begini][beginj].transform.localPosition.z;
                    x2 = tuiles[endi][endj].transform.localPosition.x;
                    y2 = tuiles[endi][endj].transform.localPosition.y;
                    z2 = tuiles[endi][endj].transform.localPosition.z;

                    // init the animation clip for the first tile
                    newAnim = new AnimationClip();
                    newAnim.legacy = true;
                    newAnim.name = "exchange";
                    curvex = AnimationCurve.Linear(0, x1, speed, x2);
                    curvey = AnimationCurve.Linear(0, y1, speed, y2);
                    curvez = AnimationCurve.Linear(0, z1, speed, z2);
                    newAnim.SetCurve("", typeof(Transform), "localPosition.x", curvex);
                    newAnim.SetCurve("", typeof(Transform), "localPosition.y", curvey);
                    newAnim.SetCurve("", typeof(Transform), "localPosition.z", curvez);
                    anim1.AddClip(newAnim, newAnim.name);
                    anim1.clip = newAnim;

                    // init the animation clip for the second tile
                    newAnim = new AnimationClip();
                    newAnim.name = "exchange";
                    newAnim.legacy = true;
                    curvex = AnimationCurve.Linear(0, x2, speed, x1);
                    curvey = AnimationCurve.Linear(0, y2, speed, y1);
                    curvez = AnimationCurve.Linear(0, z2, speed, z1);
                    newAnim.SetCurve("", typeof(Transform), "localPosition.x", curvex);
                    newAnim.SetCurve("", typeof(Transform), "localPosition.y", curvey);
                    newAnim.SetCurve("", typeof(Transform), "localPosition.z", curvez);
                    anim2.AddClip(newAnim, newAnim.name);
                    anim2.clip = newAnim;

                    // play animations
                    anim1.Play();
                    anim2.Play();

                    // exchange the tiles between them
                    tuiles[begini][beginj] = tuiles[endi][endj];
                    tuiles[begini][beginj].GetComponent<Tuile>().i = begini;
                    tuiles[begini][beginj].GetComponent<Tuile>().j = beginj;
                    tuiles[endi][endj] = exch;
                    tuiles[endi][endj].GetComponent<Tuile>().i = endi;
                    tuiles[endi][endj].GetComponent<Tuile>().j = endj;
                    
                    begini = -1; beginj = -1;
                    endi = -1; endj = -1;
                }
            }

            // determine if the player won the game
            if (win()) {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.5f, 0);
                locked = true;
            };
        }
    }


    private int[] GenNumberSequence(int limit)
    {
        List<int> dejavu = new List<int>();
        int[] numbers = new int[limit];
        int currentNumber = 0, rand;

        Random.InitState((int) System.DateTime.Now.Ticks);
        for (int i = 0; i < limit; i++)
        {
            do {
                rand = Random.Range(0, limit);
            } while (dejavu.Contains(rand));

            numbers[rand] = currentNumber++;
            dejavu.Add(rand);
        }

        return numbers;
    }


    private bool win() {
        
        for (int i = 0; i < n; i++) {
           for (int j = 0; j < n; j++) {
               if ((i != n-1 || j != n-1) && tuiles[i][j].GetComponent<Tuile>().value != (i*n+j+1)) {
                    return false;
               }
            }    
        }

        if (tuiles[n - 1][n - 1].GetComponent<Tuile>().value != 0)
            return false;

        return true;
    }
}
