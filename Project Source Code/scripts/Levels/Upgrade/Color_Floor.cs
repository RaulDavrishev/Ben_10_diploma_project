using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Floor : MonoBehaviour{
    public Material mat;

    bool change;

    byte red = 0;
    byte green = 255;
    byte blue = 0; 


    void Start(){
        mat.color = new Color32(red, blue, green, 255);
    }

    void Update(){
        if(!change){
            StartCoroutine(TimeDelay()); 
        }
        
    }

    IEnumerator TimeDelay(){
        change = true;
        yield return new WaitForSeconds(0.001f);
        if(red < 255 && green == 255 && blue == 0){ red+=5; }
        else if(red == 255 && green > 0 && blue == 0 ){ green-=5; }
        else if(red == 255 && green == 0 && blue < 255){ blue+=5; }
        else if(red > 0 && green == 0 && blue == 255){ red-=5; }
        else if(red == 0 && green < 255 && blue == 255){ green+=5; }
        else if(red == 0 && green == 255 && blue > 0){ blue-=5; }
        mat.color = new Color32(red, blue, green, 255);
        change = false;
    }
}
