using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour{

    public Image img;
    public Text txt;

    public GameObject YouWinImg;

    bool change;

    byte red = 0;
    byte green = 255;
    byte blue = 0; 


    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        img.color = new Color32(red, blue, green, 255);
        txt.color = new Color32(green, blue, red, 255);
        StartCoroutine(TimeDelay2());
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
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
        img.color = new Color32(red, blue, green, 255);
        txt.color = new Color32(green, blue, red, 255);
        change = false;
    }

    IEnumerator TimeDelay2(){
        yield return new WaitForSeconds(36.0f);
        YouWinImg.SetActive(true);
    }

}
