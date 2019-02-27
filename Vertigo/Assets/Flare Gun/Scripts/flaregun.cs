using UnityEngine;
using System.Collections;

public class flaregun : MonoBehaviour {
	
	public Rigidbody flareBullet;
	public Transform barrelEnd;
	public AudioClip flareShotSound;	
	public int bulletSpeed = 2000;
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (/*Input.GetButtonDown("Oculus_CrossPlatform_PrimaryHandTrigger")*/OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0 && !GetComponent<Animation>().isPlaying)
        {
            Shoot();
        }
	}
	
	void Shoot()
	{
	    GetComponent<Animation>().CrossFade("Shoot");
		GetComponent<AudioSource>().PlayOneShot(flareShotSound);
        Rigidbody bulletInstance;			
		bulletInstance = Instantiate(flareBullet,barrelEnd.position,barrelEnd.rotation) as Rigidbody; //INSTANTIATING THE FLARE PROJECTILE
		bulletInstance.AddForce(barrelEnd.forward * bulletSpeed); //ADDING FORWARD FORCE TO THE FLARE PROJECTILE

          
	}
}
