using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ChangeColorPaint : MonoBehaviour {
    Image m_Image;
    public Sprite [] m_Sprite;
    private int counter = 0;

    // Start is called before the first frame update
    void Start() {
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();
        m_Image.sprite = m_Sprite[0];
    }

    // Update is called once per frame
    void Update() {

        //Press space to change the Sprite of the Image
		if (OVRInput.GetDown(OVRInput.Button.Two)/*Input.GetKeyDown("Oculus_CrossPlatform_Button2")*/) {
            counter ++;

            if (counter == m_Sprite.Length){
                counter = 0;
            }

            m_Image.sprite = m_Sprite[counter];
        }
        
    }

    public int GetCounter() {
        return counter; 
    }
}
