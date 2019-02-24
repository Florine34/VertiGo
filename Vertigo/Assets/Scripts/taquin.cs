using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class taquin : MonoBehaviour
{
    public int n;
    public GameObject modele;
    public Material highlight;
    public Material baseMaterial; 
    private Animation animation;
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
        float x = transform.GetChild(0).position.x - transform.GetChild(0).localScale.x/2f + w/2f + border/2f, y = transform.GetChild(0).position.y + transform.GetChild(0).localScale.y/2f - h/2f - border/2f;
        int[] numbers = GenNumberSequence(n*n);

        animation = GetComponent<Animation>();

        // init tiles
        if (modele != null) {
            tuiles = new GameObject[n][];

            for (int i = 0; i < n; i ++) {
                tuiles[i] = new GameObject[n];
                for (int j = 0; j < n; j ++) {
                    // create the new tile from left to right
                    tuiles[i][j] = Instantiate(modele);
                    tuiles[i][j].transform.SetParent(transform.GetChild(1));
                    tuiles[i][j].layer = 9;
                    tuiles[i][j].transform.position = new Vector3(x + j*(w+border), y - i*(h + border), transform.position.z - 0.015f);
                    tuiles[i][j].transform.localScale = new Vector3(w, h, border);
                    // assign a number different between each tiles
                    tuiles[i][j].GetComponent<Tuile>().value = numbers[i*n+j];
                    tuiles[i][j].transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = numbers[i*n+j].ToString();
                    tuiles[i][j].GetComponent<Tuile>().i = i;
                    tuiles[i][j].GetComponent<Tuile>().j = j;
                    tuiles[i][j].GetComponent<Tuile>().parent = this;
                    if (tuiles[i][j].GetComponent<Tuile>().value == 0) {
                        tuiles[i][j].GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }

        }
    }

    // Update is called once per frame
    void Update() {

        if (!locked)
        {
            if (begini > -1 && beginj > -1)
            {
                //Debug.Log("Touché1? : " + begini + " " + beginj);
                tuiles[begini][beginj].GetComponent<Renderer>().material.color = Color.red;

                if (begini-1 >= 0)
                    tuiles[begini-1][beginj].GetComponent<Renderer>().material = highlight;
                if (beginj-1 >= 0)
                    tuiles[begini][beginj-1].GetComponent<Renderer>().material = highlight;
                if (begini+1 < n)
                    tuiles[begini+1][beginj].GetComponent<Renderer>().material = highlight;
                if (beginj+1 < n)
                    tuiles[begini][beginj+1].GetComponent<Renderer>().material = highlight;
            }

            if (endi > -1 && endj > -1)
            {
                //Debug.Log("TOOOOUUUUUCHEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE? : " + endi + " " + endj);
                tuiles[endi][endj].GetComponent<Renderer>().material.color = Color.red;

                if (begini - 1 >= 0)
                    tuiles[begini - 1][beginj].GetComponent<Renderer>().material = baseMaterial;
                if (beginj - 1 >= 0)
                    tuiles[begini][beginj - 1].GetComponent<Renderer>().material = baseMaterial;
                if (begini + 1 < n)
                    tuiles[begini + 1][beginj].GetComponent<Renderer>().material = baseMaterial;
                if (beginj + 1 < n)
                    tuiles[begini][beginj + 1].GetComponent<Renderer>().material = baseMaterial;
            }

            if (begini > -1 && beginj > -1 && endi > -1 && endj > -1)
            {
                AnimationCurve curvex;
                GameObject exch = tuiles[begini][beginj];
                Vector3 translate1 = new Vector3(tuiles[begini][beginj].transform.position.x - tuiles[endi][endj].transform.position.x,
                                                tuiles[begini][beginj].transform.position.y - tuiles[endi][endj].transform.position.y,
                                                tuiles[begini][beginj].transform.position.z - tuiles[endi][endj].transform.position.z);


                //Debug.Log("Ok j'échange! " + begini + " " + beginj + "   " + endi + " " + endj);

                // exchange the position
                //tuiles[begini][beginj].transform.Translate(-translate1, Space.Self);
                //tuiles[endi][endj].transform.Translate(translate1, Space.Self);

                if (!animation.isPlaying)
                {
                    animation.clip.ClearCurves();
                    curvex = AnimationCurve.Linear(0, /*tuiles[begini][beginj].*/transform.position.x, 1, /*tuiles[endi][endj].*/transform.position.x+2);
                    animation.clip.SetCurve("", typeof(Transform), "Position.x", curvex);
                    StartCoroutine(DelayedAnimation());

                    // exchange the tiles between them
                    tuiles[begini][beginj] = tuiles[endi][endj];
                    tuiles[begini][beginj].GetComponent<Tuile>().i = begini;
                    tuiles[begini][beginj].GetComponent<Tuile>().j = beginj;
                    tuiles[endi][endj] = exch;
                    tuiles[endi][endj].GetComponent<Tuile>().i = endi;
                    tuiles[endi][endj].GetComponent<Tuile>().j = endj;

                    // change material
                    tuiles[begini][beginj].GetComponent<Renderer>().material = baseMaterial;
                    tuiles[endi][endj].GetComponent<Renderer>().material = baseMaterial;


                    //Debug.Log("Probleme1? (" + tuiles[begini][beginj].GetComponent<Tuile>().i + " " + tuiles[begini][beginj].GetComponent<Tuile>().j + ")   (" + tuiles[endi][endj].GetComponent<Tuile>().i + " " + tuiles[endi][endj].GetComponent<Tuile>().j + ")");
                    begini = -1; beginj = -1;
                    endi = -1; endj = -1;
                    //Debug.Log("Probleme2? (" + begini + " " + beginj + ")   (" + endi + " " + endj + ")");
                }
            }

            // determine if the player won the game  
            if (win())
            {
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


    private IEnumerator DelayedAnimation() {
        yield return new WaitForSeconds(1);
        animation.Play();
    }
}
