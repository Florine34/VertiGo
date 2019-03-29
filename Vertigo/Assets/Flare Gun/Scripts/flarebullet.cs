using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class flarebullet : MonoBehaviour {
		
	private AudioSource flaresound;
	public AudioClip flareBurningSound;
    private ParticleSystem ps;
    private ChangeColorPaint color;
    ParticleSystem.MainModule main;
    private int countRightColor = 0;
    private List<int> tabBonOrdre = new List<int>{ 1, 2, 3, 4, 5 }; 
    private List<int> tabAVerifier = new List<int>(5);
    public OpenDoor door;
    public bool couleurBonOrdre; 

    // Use this for initialization
    void Start () {
		
		GetComponent<AudioSource>().PlayOneShot(flareBurningSound);
		flaresound = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
        color = GameObject.Find("Paint").GetComponent<ChangeColorPaint>();
        main = ps.main;
        main.startColor = new Color(0, 0, 100);
    }

    void Update()
    {
        SetColor(); 
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "SphereAColorier")
       {
            Destroy(gameObject);
            other.GetComponent<Renderer>().material.color = main.startColor.color;
       }
        switch (other.gameObject.name)
        {
            case "SphereJaune":
                if(other.GetComponent<Renderer>().material.color == Color.yellow)
                {
                    countRightColor++;
                    tabAVerifier.Add(1); 
                }
                break;
            case "SphereVert":
                if (other.GetComponent<Renderer>().material.color == Color.green)
                {
                    countRightColor++;
                    tabAVerifier.Add(3);
                }
                break;
            case "SphereCyan":
                if (other.GetComponent<Renderer>().material.color == Color.cyan)
                {
                    countRightColor++;
                    tabAVerifier.Add(5);
                }
                break;
           /* case "SphereBleu":
                if (other.GetComponent<Renderer>().material.color == Color.blue)
                {
                    countRightColor++;
                    tabAVerifier.Add(5);
                }
                break;*/
            case "SphereMagenta":
                if (other.GetComponent<Renderer>().material.color == Color.magenta)
                {
                    countRightColor++;
                    tabAVerifier.Add(2);
                }
                break;
            case "SphereMRouge":
                if (other.GetComponent<Renderer>().material.color == Color.red)
                {
                    countRightColor++;
                    tabAVerifier.Add(4);
                }
                break;

        }

        if(countRightColor == 6 && tabAVerifier == tabBonOrdre)
        {
            Debug.Log("Toutes les couleurs sont corrects et dans le bon ordre! ");
            couleurBonOrdre = true; 
            door.OpenTheDoor(); 
        }
      
    }

    void SetColor()
    {
        switch (color.GetCounter())
        {
            case 0: // Bleu clair
                main.startColor = Color.cyan;
                break;
            case 1: // Jaune
                main.startColor = Color.yellow;
                break;
            case 2: // Magenta
                main.startColor = Color.magenta;
                break;
            case 3: // Rouge
                main.startColor = Color.red;
                break;
            case 4: // Vert 
                main.startColor = Color.green;
                break;
            case 5: // Bleu Foncé
                main.startColor = Color.blue;
                break;

        }
    }
}
