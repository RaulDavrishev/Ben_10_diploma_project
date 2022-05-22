using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreXLR8 : MonoBehaviour{

    public Animator levelLoader;

    public Text scoreText;
    bool[] state = {true, true, true, true, true, true, true, true, true, true, true};
    public GameObject[] walkmans;

    public GameObject warning_message;
    public GameObject DoneCheckBox;
    public GameObject LevelCompleteCanvas;
    public GameObject LevelComplete10;

    public GameObject[] Character_models;
    public GameObject MainLevel;
    public GameObject XLR8Level;

    public GameObject Main_Level_Position;
    public GameObject XLR8_Level_Position;

    public Text timer;
    int secondsLeft = 120;
    bool takingAway, once;

    public AudioSource sounds;
    public AudioClip coin;

    int collected = 0;

    public GameObject MainPause;
    public GameObject XLR8Pause;
    public PauseXLR8 PauseMenu;

    public GameObject BackgroundMusic;
    public GameObject XLR8Music;

    void Start(){
        MainPause.SetActive(false);
        BackgroundMusic.SetActive(false);
    }

    void Update(){
        if( collected != 10 ){ 
            warning_message.SetActive(!Character_models[10].activeSelf);
            if(takingAway == false && secondsLeft > 0){
                StartCoroutine(Timer());
            }
            else if(secondsLeft == 0 && !once){
                StartCoroutine(RetryDelay());
                once = true;
            }
        }
        else{  
            if(!LevelCompleteCanvas.activeSelf){
                timer.enabled = false;
                warning_message.SetActive(false);
                DoneCheckBox.SetActive(true); 
                LevelCompleteCanvas.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.E)){
                StartCoroutine(TimeDelay());  
            } 
        }
        
        
        
        for(int i=0; i<10; i++){
            if(!walkmans[i].activeSelf && state[i]){
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
        BackgroundMusic.SetActive(true);
        MainPause.SetActive(true);
        LevelComplete10.SetActive(false);
        MainLevel.SetActive(true);
        XLR8Level.SetActive(false);
        for(int i=0; i<=10; i++){
            if(Character_models[i].activeSelf){
                Character_models[i].SetActive(false);
                Character_models[i].transform.position = Main_Level_Position.transform.position;
                Character_models[i].SetActive(true);
            } 
        }
    }


    IEnumerator Timer(){
        takingAway = true;
        yield return new WaitForSeconds(1.0f);
        secondsLeft -= 1;
        if(secondsLeft >= 60){
            if(secondsLeft%60 < 10){timer.text = "01:0" + secondsLeft%60;}
            else{timer.text = "01:" + secondsLeft%60;}
        }else{
           if(secondsLeft < 10){timer.text = "00:0" + secondsLeft%60;}
            else{timer.text = "00:" + secondsLeft%60;} 
        }
        
        takingAway = false;
    }



    public void Retry(){
        PauseMenu.Change();
        StartCoroutine(RetryDelay());
    }

    IEnumerator RetryDelay(){
        levelLoader.SetTrigger("start");
        XLR8Music.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        XLR8Music.SetActive(true);
        for(int i=0; i<=10; i++){
            if(Character_models[i].activeSelf){
                Character_models[i].SetActive(false);
                Character_models[i].transform.position = XLR8_Level_Position.transform.position;
                Character_models[i].SetActive(true);
            } 
        }

        secondsLeft = 120;
        collected = 0;
        once = false;

        for(int i=0; i<10; i++){
            state[i] = true;
            walkmans[i].SetActive(true);
        }
    }



}
