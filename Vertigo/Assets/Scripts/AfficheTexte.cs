using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfficheTexte : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public string codeEntre { get; set; }
    void Start()
    {
        codeEntre = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AfficherTexte()
    {
        transform.GetChild(0).GetComponent<TextMeshPro>().SetText(codeEntre);
    }
}
