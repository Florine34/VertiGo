using System;
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
    public int zeroi, zeroj;
    [HideInInspector]
    public int endi, endj;



    // Start is called before the first frame update
    void Start() {
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
                    tuiles[i][j].transform.localRotation = new Quaternion(0, 0, 0, 1);
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
                        tuiles[i][j].layer = 0;
                        tuiles[i][j].transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
                        zeroi = i; zeroj = j;
                    }
                }
            }

            EnableHighLightTiles();
        }
    }


    // Update is called once per frame
    void Update() {
        int k;
        int offseti = 0, offsetj = 0, offset, i1, j1, i2, j2;
        float x, y, z;

        // block the game if game is over
        if (!locked) {

            if (endi > -1 && endj > -1) {
                AnimationCurve curvex, curvey, curvez;
                AnimationClip newAnim;
                Animation anim;
                GameObject boxZero;
                List<Vector3> dest = new List<Vector3>();
                List<Animation> anims = new List<Animation>();

                // calculate number of deplacement
                if (zeroi != endi) {
                    offseti = endi - zeroi;
                    offset = offseti;
                    offseti = offseti / Math.Abs(offseti);
                } else {
                    offsetj = endj - zeroj;
                    offset = offsetj;
                    offsetj = offsetj / Math.Abs(offsetj);
                }

                offset = Math.Abs(offset);

                // get position of all tiles which will move and their animation component
                dest.Add(new Vector3(tuiles[zeroi][zeroj].transform.localPosition.x, tuiles[zeroi][zeroj].transform.localPosition.y, tuiles[zeroi][zeroj].transform.localPosition.z));
                anims.Add(tuiles[zeroi][zeroj].GetComponent<Animation>());
                for (int d = 1; d <= offset; d++) {

                    if (offseti != 0) {
                        k = offseti * d;
                        x = tuiles[zeroi + k][zeroj].transform.localPosition.x;
                        y = tuiles[zeroi + k][zeroj].transform.localPosition.y;
                        z = tuiles[zeroi + k][zeroj].transform.localPosition.z;
                        anim = tuiles[zeroi + k][zeroj].GetComponent<Animation>();
                    } else {
                        k = offsetj * d;
                        x = tuiles[zeroi][zeroj + k].transform.localPosition.x;
                        y = tuiles[zeroi][zeroj + k].transform.localPosition.y;
                        z = tuiles[zeroi][zeroj + k].transform.localPosition.z;
                        anim = tuiles[zeroi][zeroj + k].GetComponent<Animation>();
                    }

                    anims.Add(anim);
                    dest.Add(new Vector3(x, y, z));
                }


                //Debug.Log("Playing :  " + AnimationPlayed(anims));
                if (!AnimationPlayed(anims)) {
                    DisableHighLightTiles();  // disable the mark on adjacent tiles 

                    // init the animation clip for each tile except the first
                    for (int a = anims.Count-1; a > 0; a--) {
                        newAnim = new AnimationClip();
                        newAnim.legacy = true;
                        newAnim.name = "exchange";
                        curvex = AnimationCurve.Linear(0, dest[a].x, speed, dest[a-1].x);
                        curvey = AnimationCurve.Linear(0, dest[a].y, speed, dest[a-1].y);
                        curvez = AnimationCurve.Linear(0, dest[a].z, speed, dest[a-1].z);
                        newAnim.SetCurve("", typeof(Transform), "localPosition.x", curvex);
                        newAnim.SetCurve("", typeof(Transform), "localPosition.y", curvey);
                        newAnim.SetCurve("", typeof(Transform), "localPosition.z", curvez);
                        anims[a].AddClip(newAnim, newAnim.name);
                        anims[a].clip = newAnim;
                    }

                    // init the animation clip for the first tile
                    newAnim = new AnimationClip();
                    newAnim.name = "exchange";
                    newAnim.legacy = true;
                    curvex = AnimationCurve.Linear(0, dest[0].x, speed, dest[anims.Count - 1].x);
                    curvey = AnimationCurve.Linear(0, dest[0].y, speed, dest[anims.Count - 1].y);
                    curvez = AnimationCurve.Linear(0, dest[0].z, speed, dest[anims.Count - 1].z);
                    newAnim.SetCurve("", typeof(Transform), "localPosition.x", curvex);
                    newAnim.SetCurve("", typeof(Transform), "localPosition.y", curvey);
                    newAnim.SetCurve("", typeof(Transform), "localPosition.z", curvez);
                    anims[0].AddClip(newAnim, newAnim.name);
                    anims[0].clip = newAnim;
                    
                    // play animations
                    PlayAnimations(anims);

                    // exchange each tiles in the matrix
                    // save the first tile
                    boxZero = tuiles[zeroi][zeroj];

                    // move all tiles of 1 tile to left
                    for (int a = 0; a < anims.Count - 1; a ++) {
                        if (offseti != 0) {
                            i1 = a * offseti; j1 = 0;
                            i2 = (a + 1) * offseti; j2 = 0;
                        } else {
                            i1 = 0; j1 = a * offsetj;
                            i2 = 0; j2 = (a + 1) * offsetj;
                        }
                        
                        tuiles[zeroi + i1][zeroj + j1] = tuiles[zeroi + i2][zeroj + j2];
                        tuiles[zeroi + i1][zeroj + j1].GetComponent<Tuile>().i = zeroi + i1;
                        tuiles[zeroi + i1][zeroj + j1].GetComponent<Tuile>().j = zeroj + j1;
                        //Debug.Log("i1 : " + (zeroi + i1) + "  j1 : " + (zeroj + j1) + "  i2 : " + (zeroi + i2) + "  j2 : " + (zeroj + j2));
                    }

                    // replace the first tile to last location
                    //Debug.Log("endi : " + endi + " endj : " + endj);
                    tuiles[endi][endj] = boxZero;
                    tuiles[endi][endj].GetComponent<Tuile>().i = endi;
                    tuiles[endi][endj].GetComponent<Tuile>().j = endj;
                    //Debug.Log("endi : " + endi + " endj : " + endj);
                    
                    /*String message = "";
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            message += tuiles[i][j].GetComponent<Tuile>().value + " (" + tuiles[i][j].GetComponent<Tuile>().i + " " + tuiles[i][j].GetComponent<Tuile>().j + ") ";
                        }
                        message += "\n";
                    }
                    Debug.Log(message);*/

                    zeroi = endi; zeroj = endj;
                    endi = -1; endj = -1;

                    EnableHighLightTiles();
                }
            }

            // determine if the player won the game
            if (win()) {
                DisableHighLightTiles();
                DisableNumbers();
                tuiles[zeroi][zeroj].GetComponent<Renderer>().enabled = true;   // shown the missing tile
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.5f, 0);   // mark the taquin object to shown the victory
                locked = true;    // block the game system
            };
        }
    }


    private bool AnimationPlayed(List<Animation> anims) {

        for (int i = 0; i < anims.Count; i++) {
            if (anims[i].isPlaying) {
                return true;
            }
        }

        return false;
    }

    private void PlayAnimations(List<Animation> anims)
    {

        for (int i = 0; i < anims.Count; i++)
        {
            if (!anims[i].isPlaying) {
                anims[i].Play();
            }

            //Debug.Log("Animation "+i+" : "+anims[i].isPlaying);
        }
    }

    private void EnableHighLightTiles()
    {
        for (int i = 1; i <= n-1; i++) {
            if (zeroi - i >= 0)
                tuiles[zeroi - i][zeroj].GetComponent<Renderer>().materials = new Material[2] { tuiles[zeroi - i][zeroj].GetComponent<Renderer>().material, highlight };
            if (zeroj - i >= 0)
                tuiles[zeroi][zeroj - i].GetComponent<Renderer>().materials = new Material[2] { tuiles[zeroi][zeroj - i].GetComponent<Renderer>().material, highlight };
            if (zeroi + i < n)
                tuiles[zeroi + i][zeroj].GetComponent<Renderer>().materials = new Material[2] { tuiles[zeroi + i][zeroj].GetComponent<Renderer>().material, highlight };
            if (zeroj + i < n)
                tuiles[zeroi][zeroj + i].GetComponent<Renderer>().materials = new Material[2] { tuiles[zeroi][zeroj + i].GetComponent<Renderer>().material, highlight };
        }
    }


    private void DisableHighLightTiles()
    {

        for (int i = 1; i <= n - 1; i++)
        {
            if (zeroi - i >= 0)
                tuiles[zeroi - i][zeroj].GetComponent<Renderer>().materials = new Material[1] { tuiles[zeroi - i][zeroj].GetComponent<Renderer>().material };
            if (zeroj - i >= 0)
                tuiles[zeroi][zeroj - i].GetComponent<Renderer>().materials = new Material[1] { tuiles[zeroi][zeroj - i].GetComponent<Renderer>().material };
            if (zeroi + i < n)
                tuiles[zeroi + i][zeroj].GetComponent<Renderer>().materials = new Material[1] { tuiles[zeroi + i][zeroj].GetComponent<Renderer>().material };
            if (zeroj + i < n)
                tuiles[zeroi][zeroj + i].GetComponent<Renderer>().materials = new Material[1] { tuiles[zeroi][zeroj + i].GetComponent<Renderer>().material };
        }
    }

    private void DisableNumbers() {

        for (int i = 0; i < tuiles.Length; i++) {
            for (int j = 0; j < tuiles.Length; j++) {
                tuiles[i][j].transform.GetChild(0).gameObject.SetActive(false);
            }
        }

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


    private int[] GenNumberSequence(int limit)
    {
        List<int> dejavu;
        int[] numbers = new int[limit];
        int currentNumber = 0, c = 0, rand;


        do
        {
            // init the value to generate the good number sequence
            UnityEngine.Random.InitState((int) DateTime.Now.Ticks);
            dejavu = new List<int>();
            currentNumber = 0;

            for (int i = 0; i < limit; i++)
            {
                do
                {
                    rand = UnityEngine.Random.Range(0, limit);
                } while (dejavu.Contains(rand));

                numbers[rand] = currentNumber++;
                dejavu.Add(rand);
            }
        } while (!IsValid(numbers, (int)(Math.Sqrt(limit))));

        return numbers;
    }

    private bool IsValid(int[] numbers, int dim) {
        int size = dim * dim;
        int[] tmp_numbers = new int[size];
        int parity = 0, switches = 0, i, exch;
        String message = "";

        for (i = 0; i < dim; i++)
        {
            for (int j = 0; j < dim; j++)
            {
                message += numbers[i * dim + j] + " ";
            }
            message += "\n";
        }

        Debug.Log(message);

        // search the box with the value 0
        for (i = 0; numbers[i] != 0; i++) ;
        // compute the parity of this box
        parity = (dim - 1) + (dim - 1) - ((i / dim) + (i % dim));

        // compute the number of switches
        Array.Copy(numbers, 0, tmp_numbers, 0, size);

        // switch the box with value 0 and the last box in the matrix
        if (i < size - 1) {
            exch = tmp_numbers[size-1];
            tmp_numbers[size - 1] = tmp_numbers[i];
            tmp_numbers[i] = exch;
            switches++;
        }

        // switch boxes as long as the values are not sorted
        for (i = size - 1; i > 0; i--) {
            if (tmp_numbers[i - 1] < i) {
                for (int j = i - 1; j >= 0; j--) {
                    if (tmp_numbers[j] == i) {
                        exch = tmp_numbers[j];
                        tmp_numbers[j] = tmp_numbers[i-1];
                        tmp_numbers[i-1] = exch;
                        switches++;
                    }
                }
            }
        }

        Debug.Log("parity : " + parity  + "   switches : " + switches + "   dim : " + dim);

        return (parity % 2 == 1) ^ (switches % 2 == 1);
    }
}
