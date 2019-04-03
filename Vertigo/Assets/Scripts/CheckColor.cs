using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;


public class CheckColor : MonoBehaviour {
    public OpenDoor door;
    private ChangeColorPaint color;
    private CollisionPainter painter;
    private int countRightColor = 0;
    private List<int> tabBonOrdre = new List<int> { 1, 2, 3, 4, 5 };
    private List<int> tabAVerifier = new List<int>(5);
    [HideInInspector]
    public bool couleurBonOrdre;


    // Start is called before the first frame update
    void Start(){


    }

    public void ManageColor(string tagSphere, Color ballColor) {

        switch (tagSphere) {
            case "SphereJaune":
                if (ballColor == Color.yellow)
                {
                    countRightColor++;
                    tabAVerifier.Add(1);
                }
                break;
            case "SphereVert":
                if (ballColor == Color.green)
                {
                    countRightColor++;
                    tabAVerifier.Add(3);
                }
                break;
            case "SphereCyan":
                if (ballColor == Color.cyan) {
                    countRightColor++;
                    tabAVerifier.Add(5);
                }
                break;
            case "SphereMagenta":
                if (ballColor == Color.magenta) {
                    countRightColor++;
                    tabAVerifier.Add(2);
                }

                break;
            case "SphereMRouge":
                if (ballColor == Color.red) {
                    countRightColor++;
                    tabAVerifier.Add(4);
                }
                break;

        }

        if (countRightColor == 6 && tabAVerifier == tabBonOrdre) {
            Debug.Log("Toutes les couleurs sont corrects et dans le bon ordre! ");
            couleurBonOrdre = true;
            door.OpenTheDoor();
        }
    }
}
