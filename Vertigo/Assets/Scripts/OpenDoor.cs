using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
 
    private Animator animDoor;
    int doorOpen = 0;
    public CheckColor couleur;

    // Start is called before the first frame update
    void Start()
    {
        animDoor = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTheDoor() {
        bool couleurReussi = false;
        doorOpen ++;

        if (couleur != null) couleurReussi = couleur.couleurBonOrdre;

        if(doorOpen == 3 || couleurReussi == true) {
            animDoor.SetBool("open", true);
        }
        
    }

    public void CloseTheDoor()
    {
        doorOpen--;
        animDoor.SetBool("open", false);
    }

}
