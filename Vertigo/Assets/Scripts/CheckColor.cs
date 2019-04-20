using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;




public class CheckColor : MonoBehaviour {
    public OpenDoor door;
    private CollisionPainter painter;
    private int countRightColor = 0;
    private List<bool> sphereColorie;
    //private List<int> tabBonOrdre = new List<int> { 1, 2, 3, 4, 5 };
    //private List<int> tabAVerifier = new List<int>(5);
    [HideInInspector]
    public bool couleurBonOrdre;


    // Start is called before the first frame update
    void Start(){
        sphereColorie = new List<bool>(5);

        for (int i = 0; i < sphereColorie.Count; i++) {
            sphereColorie[i] = false;
        }
    }

    public void ManageColor(string tagSphere, Color ballColor) {

        switch (tagSphere) {
            case "SphereJaune":

                if (ballColor == Color.yellow) {
                    //countRightColor++;
                    sphereColorie[0] = true;
                }

                break;
            case "SphereVert":

                if (ballColor == Color.green) {
                    //countRightColor++;
                    sphereColorie[1] = true;
                }

                break;
            case "SphereCyan":

                if (ballColor == Color.cyan) {
                    //countRightColor++;
                    sphereColorie[2] = true;
                }

                break;
            case "SphereMagenta":

                if (ballColor == Color.magenta) {
                    //countRightColor++;
                    sphereColorie[3] = true;
                }

                break;
            case "SphereMRouge":

                if (ballColor == Color.red) {
                    //countRightColor++;
                    sphereColorie[4] = true;
                }

                break;
        }

        countRightColor = 0;
        foreach (var sphere in sphereColorie) {
            if (sphere)
                countRightColor ++;
        }

        if (countRightColor == 5/* && tabAVerifier == tabBonOrdre*/) {
            Debug.Log("Toutes les couleurs sont corrects et dans le bon ordre!");
            couleurBonOrdre = true;
            door.OpenTheDoor();
        }
    }
}
