using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonWin : MonoBehaviour
{
    public AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
        
     this.GetComponent<AudioSource>().enabled = true;

    }
}
