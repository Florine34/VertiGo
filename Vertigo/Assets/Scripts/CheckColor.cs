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
        sphereColorie = new List<bool>();

        for (int i = 0; i < 5; i++) {
            sphereColorie.Add(false);
        }
    }

    public void ManageColor(string tagSphere, Color ballColor) {

        switch (tagSphere) {
            case "SphereJauneS":

                if (ballColor == Color.yellow) {
                    //countRightColor++;
                    sphereColorie[0] = true;
                }

                break;
            case "SphereVertS":

                if (ballColor == Color.green) {
                    //countRightColor++;
                    sphereColorie[1] = true;
                }

                break;
            case "SphereCyanS":

                if (ballColor == Color.cyan) {
                    //countRightColor++;
                    sphereColorie[2] = true;
                }

                break;
            case "SphereMagentaS":

                if (ballColor == Color.magenta) {
                    //countRightColor++;
                    sphereColorie[3] = true;
                }

                break;
            case "SphereRougeS":

                if (ballColor == Color.red) {
                    //countRightColor++;
                    sphereColorie[4] = true;
                }

                break;
        }

        countRightColor = 0;
        foreach (var sphere in sphereColorie) {
            Debug.LogError("" + sphere);
            if (sphere)
                countRightColor ++;
        }

        Debug.LogError("Count : " + countRightColor);
        if (countRightColor == 5/* && tabAVerifier == tabBonOrdre*/) {
            Debug.LogError("Toutes les couleurs sont corrects et dans le bon ordre!");
            couleurBonOrdre = true;
            door.OpenTheDoor();
        }
    }
}
