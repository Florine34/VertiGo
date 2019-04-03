using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
 
    private Animator animDoor;
    int doorOpen = 0;
    public flarebullet couleur;

    // Start is called before the first frame update
    void Start()
    {
        animDoor = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTheDoor()
    {
        doorOpen++;
        if(doorOpen == 3 || couleur.couleurBonOrdre == true)
        {
            animDoor.SetBool("open", true);
        }
        
    }

    public void CloseTheDoor()
    {
        doorOpen--;
        animDoor.SetBool("open", false);
    }

}
