using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStinkyfly : MonoBehaviour{

    public Animator levelLoader;

    public Text scoreText;
    bool[] state = {true, true, true, true, true, true, true, true, true, true, true};

    public GameObject[] coins;
    public GameObject warning_message;
    public GameObject DoneCheckBox;
    public GameObject LevelCompleteCanvas;
    public GameObject LevelComplete7;

    public GameObject[] Character_models;
    public GameObject MainLevel;
    public GameObject StinkyflyLevel;

    public GameObject Main_Level_Position;

    public AudioSource sounds;
    public AudioClip coin;

    int collected = 0;



    void Update(){

        if( collected != 10 ){ warning_message.SetActive(!Character_models[7].activeSelf); }
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
        
        
        
        for(int i=0; i<10; i++){
            if(!coins[i].activeSelf && state[i]){
                collected++;
                state[i] = false;
                sounds.PlayOneShot(coin, 0.5f);
                scoreText.text = "(" + collected + "/10)";
            }
        }

    }


    IEnumerator TimeDelay(){
        levelLoader.SetTrigger("start");
        yield return new WaitForSeconds(1.0f);
        LevelComplete7.SetActive(false);
        MainLevel.SetActive(true);
        StinkyflyLevel.SetActive(false);
        for(int i=0; i<=10; i++){
            if(Character_models[i].activeSelf){
                Character_models[i].SetActive(false);
                Character_models[i].transform.position = Main_Level_Position.transform.position;
                Character_models[i].SetActive(true);
            } 
        }
    }


}
