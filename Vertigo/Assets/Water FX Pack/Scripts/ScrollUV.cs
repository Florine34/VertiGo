using System;
using UnityEngine;


public class ScrollUV : MonoBehaviour{
    float scrollSpeed_X = 0.5f;
    float scrollSpeed_Y = 0.5f;

    void Update() {
        var offsetX = Time.time * scrollSpeed_X;
        var offsetY = Time.time * scrollSpeed_Y;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}