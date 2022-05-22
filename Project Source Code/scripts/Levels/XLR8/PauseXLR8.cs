using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseXLR8 : MonoBehaviour{

    public GameObject PauseMenu;
    public GameObject Omnitrix_UI;

    public bool Paused;

    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape)){
            Change();
        }

        if(Paused){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            PauseMenu.SetActive(true);
            AudioListener.pause = true;
            Omnitrix_UI.SetActive(false);
        }else{
            if(PauseMenu.activeSelf){
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                PauseMenu.SetActive(false);
                AudioListener.pause = false;
                Omnitrix_UI.SetActive(true);
            }
        }

    }

    public void Resume(){
        Paused = false;
    }

    public void Exit(){
        Application.Quit();
    }


    public void Change(){
        Paused = !Paused;
    }
    

}
