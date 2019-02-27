using UnityEngine;
using System.Collections;

public class flarebullet : MonoBehaviour {
		
	private AudioSource flaresound;
	public AudioClip flareBurningSound;
    private ParticleSystem ps;
    private ChangeColorPaint color;
    ParticleSystem.MainModule main;
    private int countRightColor = 0; 

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
                }
                break;
            case "SphereVert":
                if (other.GetComponent<Renderer>().material.color == Color.green)
                {
                    countRightColor++;
                }
                break;
            case "SphereCyan":
                if (other.GetComponent<Renderer>().material.color == Color.cyan)
                {
                    countRightColor++;
                }
                break;
            case "SphereBleu":
                if (other.GetComponent<Renderer>().material.color == Color.blue)
                {
                    countRightColor++;
                }
                break;
            case "SphereMagenta":
                if (other.GetComponent<Renderer>().material.color == Color.magenta)
                {
                    countRightColor++;
                }
                break;
            case "SphereMRouge":
                if (other.GetComponent<Renderer>().material.color == Color.red)
                {
                    countRightColor++;
                }
                break;

        }

        if(countRightColor == 6)
        {
            Debug.Log("Toutes les couleurs sont correct ! "); 
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
