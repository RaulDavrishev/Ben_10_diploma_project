using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGreyMatter : MonoBehaviour{
    
    public Animator levelLoader;
        
    public Animator[] anim; 
    public GameObject[] area;
    public Material[] numberLights;
    public GameObject TV;

    public GameObject warning_message;
    public GameObject DoneCheckBox;
    public GameObject LevelCompleteCanvas;
    public GameObject LevelComplete4;

    public GameObject[] Character_models;
    public GameObject MainLevel;
    public GameObject GreyMatterLevel;

    public GameObject Main_Level_Position;

    public AudioSource sounds;
    public AudioClip switch_sound;
    public AudioClip wrong_sound;



    int counterL,counterR = 0;
    bool[] L = {true, true, true, true, true};
    bool[] R = {true, true, true, true, true};

    bool wrong;



    void Start(){
        for(int i=0; i<10; i++){numberLights[i].DisableKeyword("_EMISSION");}
    }  



    void Update(){

        if( counterL + counterR != 10 ){ warning_message.SetActive( !Character_models[4].activeSelf); }
        else{  
            if(!LevelCompleteCanvas.activeSelf){
                warning_message.SetActive(false);
                DoneCheckBox.SetActive(true); 
                TV.SetActive(true);
                AudioListener.pause = true;
                LevelCompleteCanvas.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.E)){
                StartCoroutine(TimeDelay());  
            } 
        }

        Switches();
        
    }




    void Switches(){

        for(int i=0; i<5; i++){
            if(!area[i].activeSelf && L[i]){
                numberLights[i].EnableKeyword("_EMISSION");
                L[i] = false;
                counterL += 1;
                StartCoroutine(switch_sound_delay()); 
            }
        }

        for(int i=5; i<10; i++){
            if(!area[i].activeSelf && R[i-5]){
                numberLights[i].EnableKeyword("_EMISSION");
                R[i-5] = false;
                counterR += 1;
                sounds.PlayOneShot(switch_sound, 1.0f);
            }
        }

        // 4 2 5 3 1
        if( (counterL == 1 && area[3].activeSelf) || 
            (counterL == 2 && area[1].activeSelf) ||
            (counterL == 3 && area[4].activeSelf) ||
            (counterL == 4 && area[2].activeSelf)){

            if(!wrong){StartCoroutine(IncorrectL()); wrong = true;}

        }

        // 7 10 8 6 9 
        if( (counterR == 1 && area[6].activeSelf) || 
            (counterR == 2 && area[9].activeSelf) ||
            (counterR == 3 && area[7].activeSelf) ||
            (counterR == 4 && area[5].activeSelf)){

            if(!wrong){StartCoroutine(IncorrectR()); wrong = true;}

        }

    }


    IEnumerator TimeDelay(){
        TV.SetActive(false);
        levelLoader.SetTrigger("start");
        yield return new WaitForSeconds(1.0f);
        AudioListener.pause = false;
        LevelComplete4.SetActive(false);
        MainLevel.SetActive(true);
        GreyMatterLevel.SetActive(false);
        for(int i=0; i<=10; i++){
            if(Character_models[i].activeSelf){
                Character_models[i].SetActive(false);
                Character_models[i].transform.position = Main_Level_Position.transform.position;
                Character_models[i].SetActive(true);
            } 
        }
    }



    IEnumerator IncorrectL(){
        yield return new WaitForSeconds(1.0f);
        wrong = false;
        counterL = 0;
        sounds.PlayOneShot(wrong_sound, 1.5f);
        for(int i=0; i<5; i++){
            numberLights[i].DisableKeyword("_EMISSION");
            anim[i].SetBool("switch", false);
            area[i].SetActive(true);
            L[i] = true;
        }
    }

    IEnumerator IncorrectR(){
        yield return new WaitForSeconds(1.0f);
        wrong = false;
        counterR = 0;
        sounds.PlayOneShot(wrong_sound, 1.5f);
        for(int i=5; i<10; i++){
            numberLights[i].DisableKeyword("_EMISSION");
            anim[i].SetBool("switch", false);
            area[i].SetActive(true);
            R[i-5] = true;
        }
    }


    IEnumerator switch_sound_delay(){
        yield return new WaitForSeconds(0.3f);
        sounds.PlayOneShot(switch_sound, 1.0f);
    }






}
