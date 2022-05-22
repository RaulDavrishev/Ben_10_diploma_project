using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWaterHazard : MonoBehaviour{

    public Animator levelLoader;

    public Text scoreText;

    public GameObject warning_message;
    public GameObject DoneCheckBox;
    public GameObject LevelCompleteCanvas;
    public GameObject LevelComplete9;

    public GameObject[] Character_models;
    public GameObject MainLevel;
    public GameObject WaterHazardLevel;

    public GameObject Main_Level_Position;

    int thrown_ice = 0;


    void Update(){

        if( thrown_ice != 10 ){ warning_message.SetActive(!Character_models[9].activeSelf); }
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
        LevelComplete9.SetActive(false);
        MainLevel.SetActive(true);
        WaterHazardLevel.SetActive(false);
        for(int i=0; i<=10; i++){
            if(Character_models[i].activeSelf){
                Character_models[i].SetActive(false);
                Character_models[i].transform.position = Main_Level_Position.transform.position;
                Character_models[i].SetActive(true);
            } 
        }
    }



    public void Throw_ice(){
        thrown_ice++;
        scoreText.text = "(" + thrown_ice + "/10)";
    }


}
