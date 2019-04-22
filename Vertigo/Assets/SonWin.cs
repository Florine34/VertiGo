using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonWin : MonoBehaviour
{
    public AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<AudioSource>().PlayOneShot(clip);
            this.enabled = false;

        }
    }
}
