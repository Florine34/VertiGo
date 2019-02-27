﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorPaint : MonoBehaviour
{
    Image m_Image;
    public Sprite [] m_Sprite;
    private int counter = -1;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();       
    }

    // Update is called once per frame
    void Update()
    {
        //Press space to change the Sprite of the Image
        if (Input.GetKeyDown(KeyCode.C))
        {
            counter++;
            m_Image.sprite = m_Sprite[counter];
        }
      
        if (counter == m_Sprite.Length-1)
        {
            counter = -1; 
        }
        
    }

    public int GetCounter()
    {
        return counter; 
    }
}
