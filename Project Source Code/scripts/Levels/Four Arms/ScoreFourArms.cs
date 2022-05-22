using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFourArms : MonoBehaviour{

    public Animator levelLoader;

    public GameObject warning_message;
    public GameObject DoneCheckBox;
    public GameObject LevelCompleteCanvas;
    public GameObject LevelComplete2;

    public GameObject[] Character_models;
    public GameObject MainLevel;
    public GameObject FourArmsLevel;

    public GameObject Main_Level_Position;
    bool enter;



    void Update(){

        if(!enter){ warning_message.SetActive(!Character_models[2].activeSelf); }
        else{  
            if(!LevelCompleteCanvas.activeSelf){
                warning_message.SetActive(false);
                DoneCheckBox.SetActive(true); 
                LevelCompleteCanvas.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.E)){
                StartCoroutine(TimeDelay());  
            } 
        }
        
    }


    IEnumerator TimeDelay(){
        levelLoader.SetTrigger("start");
        yield return new WaitForSeconds(1.0f);
        LevelComplete2.SetActive(false);
        MainLevel.SetActive(true);
        FourArmsLevel.SetActive(false);
        for(int i=0; i<=10; i++){
            if(Character_models[i].activeSelf){
                Character_models[i].SetActive(false);
                Character_models[i].transform.position = Main_Level_Position.transform.position;
                Character_models[i].SetActive(true);
            } 
        }
    }



    public void Enter(){
        enter = true;
    }


}
