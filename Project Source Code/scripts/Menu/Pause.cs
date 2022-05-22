using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Pause : MonoBehaviour{

    public GameObject PauseMenu;
    public GameObject Omnitrix_UI;
    public GameObject GreyMatterLevel_TV;
    public VideoPlayer videoGreyMatter;

    bool Paused;

    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape)){
            Paused = !Paused;
        }

        if(Paused){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            PauseMenu.SetActive(true);
            AudioListener.pause = true;
            Omnitrix_UI.SetActive(false);
            if(GreyMatterLevel_TV.activeSelf){videoGreyMatter.Pause();}
        }else{
            if(PauseMenu.activeSelf){
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                PauseMenu.SetActive(false);
                AudioListener.pause = false;
                Omnitrix_UI.SetActive(true);
                if(GreyMatterLevel_TV.activeSelf){videoGreyMatter.Play();} 
            }
        }

    }

    public void Resume(){
        Paused = false;
    }

    public void Exit(){
        Application.Quit();
    }
    

}
