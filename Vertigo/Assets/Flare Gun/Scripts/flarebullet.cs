using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Es.InkPainter.Sample;

public class flarebullet : MonoBehaviour {
		
	private AudioSource flaresound;
	public AudioClip flareBurningSound;
    private ParticleSystem ps;
    private ChangeColorPaint color;
    private CollisionPainter painter;
    private int countRightColor = 0;
    private List<int> tabBonOrdre = new List<int>{ 1, 2, 3, 4, 5 }; 
    private List<int> tabAVerifier = new List<int>(5);
    public OpenDoor door;
    [HideInInspector]
    public bool couleurBonOrdre; 

    // Use this for initialization
    void Start () {
		//GetComponent<AudioSource>().PlayOneShot(flareBurningSound);
		//flaresound = GetComponent<AudioSource>();
        painter = GetComponent<CollisionPainter>();
        painter.brush.Color = new Color(0, 0, 100);
    }

    void Update()
    {
        SetColor(); 
    }

    private void OnColliderEnter(Collider other)
    {
       if (other.gameObject.tag == "SphereAColorier")
       {
            
            switch (other.gameObject.name)
            {
                case "SphereJaune":
                    if(painter.brush.Color == Color.yellow)
                    {
                        countRightColor++;
                        tabAVerifier.Add(1); 
                    }
                    break;
                case "SphereVert":
                    if (painter.brush.Color == Color.green)
                    {
                        countRightColor++;
                        tabAVerifier.Add(3);
                    }
                    break;
                case "SphereCyan":
                    if (painter.brush.Color == Color.cyan)
                    {
                        countRightColor++;
                        tabAVerifier.Add(5);
                    }
                    break;
                case "SphereMagenta":
                    if (painter.brush.Color == Color.magenta)
                    {
                        countRightColor++;
                        tabAVerifier.Add(2);
                    }
                    break;
                case "SphereMRouge":
                    if (painter.brush.Color == Color.red)
                    {
                        countRightColor++;
                        tabAVerifier.Add(4);
                    }
                    break;

            }

            if(countRightColor == 6 && tabAVerifier == tabBonOrdre) {
                Debug.Log("Toutes les couleurs sont corrects et dans le bon ordre! ");
                couleurBonOrdre = true; 
                door.OpenTheDoor();
            }

        }

    }

    void SetColor()
    {
        switch (color.GetCounter())
        {
            case 0: // Bleu clair
                painter.brush.Color = Color.cyan;
                break;
            case 1: // Jaune
                painter.brush.Color = Color.yellow;
                break;
            case 2: // Magenta
                painter.brush.Color = Color.magenta;
                break;
            case 3: // Rouge
                painter.brush.Color = Color.red;
                break;
            case 4: // Vert 
                painter.brush.Color = Color.green;
                break;
            case 5: // Bleu Foncé
                painter.brush.Color = Color.blue;
                break;

        }
    }
}
