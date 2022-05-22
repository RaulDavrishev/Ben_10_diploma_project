using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRath : MonoBehaviour{

    public Animator levelLoader;

    public GameObject warning_message;
    public GameObject DoneCheckBox;
    public GameObject LevelCompleteCanvas;
    public GameObject LevelComplete6;

    public GameObject[] Character_models;
    public GameObject MainLevel;
    public GameObject RathLevel;

    public GameObject Main_Level_Position;

    public GameObject Smell;
    public GameObject[] smells;
    public GameObject[] smellFX;

    public GameObject statue;

    public AudioSource sounds;
    public AudioClip sniffing;

    int counter = 0;

    void Update(){
        if(counter < 23){ 
            warning_message.SetActive(!Character_models[6].activeSelf); 
            Smell.SetActive(Character_models[6].activeSelf);
            if(!smells[counter].activeSelf){ 
                counter++; 
                if(counter < 23){ smells[counter].SetActive(true); }
                sounds.PlayOneShot(sniffing, 3.0f);
                StartCoroutine(SmellDelay());    
            }
        }
        else{ 
            if(!LevelCompleteCanvas.activeSelf){
                sounds.PlayOneShot(sniffing, 3.0f);
                StartCoroutine(SmellDelay());
                warning_message.SetActive(false);
                statue.SetActive(true);
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
        LevelComplete6.SetActive(false);
        MainLevel.SetActive(true);
        RathLevel.SetActive(false);
        for(int i=0; i<=10; i++){
            if(Character_models[i].activeSelf){
                Character_models[i].SetActive(false);
                Character_models[i].transform.position = Main_Level_Position.transform.position;
                Character_models[i].SetActive(true);
            } 
        }
    }

    IEnumerator SmellDelay(){
        yield return new WaitForSeconds(1.0f);
        smellFX[counter - 1].SetActive(false);
        yield return new WaitForSeconds(0.1f);
        if(counter < 23){ smellFX[counter].SetActive(true); }
    }


}
