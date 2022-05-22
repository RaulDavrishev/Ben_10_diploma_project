using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpgrade : MonoBehaviour{

    public Animator levelLoader;

    public GameObject warning_message;
    public GameObject DoneCheckBox;
    public GameObject LevelCompleteCanvas;
    public GameObject LevelComplete8;

    public GameObject[] Character_models;
    public GameObject MainLevel;
    public GameObject UpgradeLevel;

    public GameObject Main_Level_Position;

    public GameObject[] button_area;
    public GameObject button_area_canvas;

    bool one;

    public Material[] mat1,mat2,mat3,mat4;
    int[,] numbers = new int[10, 7] {{1,1,1,1,1,1,0},{0,1,1,0,0,0,0},{1,1,0,1,1,0,1},{1,1,1,1,0,0,1},{0,1,1,0,0,1,1},{1,0,1,1,0,1,1},{1,0,1,1,1,1,1},{1,1,1,0,0,0,0},{1,1,1,1,1,1,1},{1,1,1,1,0,1,1}};
    int counter1,counter2,counter3,counter4;



    void Start(){
        for(int i=0; i<7; i++){mat1[i].DisableKeyword("_EMISSION");mat2[i].DisableKeyword("_EMISSION");mat3[i].DisableKeyword("_EMISSION");mat4[i].DisableKeyword("_EMISSION");}
        digit1(0);digit2(0);digit3(0);digit4(0);
    }   



    void Update(){
        if( counter1 + counter2 + counter3 + counter4 != 21 ){ warning_message.SetActive(!Character_models[8].activeSelf); }
        else{  
            if(!one){
                warning_message.SetActive(false);
                DoneCheckBox.SetActive(true); 
                LevelCompleteCanvas.SetActive(true);
                button_area_canvas.SetActive(false);
                for(int i=0;i<16;i++){button_area[i].SetActive(false);}
                StartCoroutine(TimeDelay2());
            }

            if(Input.GetKeyDown(KeyCode.E) && one){
                StartCoroutine(TimeDelay());  
            } 
        }
    }



    IEnumerator TimeDelay(){
        levelLoader.SetTrigger("start");
        yield return new WaitForSeconds(1.0f);
        LevelComplete8.SetActive(false);
        MainLevel.SetActive(true);
        UpgradeLevel.SetActive(false);
        for(int i=0; i<=10; i++){
            if(Character_models[i].activeSelf){
                Character_models[i].SetActive(false);
                Character_models[i].transform.position = Main_Level_Position.transform.position;
                Character_models[i].SetActive(true);
            } 
        }
    }

    IEnumerator TimeDelay2(){
        yield return new WaitForSeconds(0.1f);
        one = true;
        
    }



    public void digit1(int num){
    	counter1+=num;
        for(int i=0; i<7; i++){
        	mat1[i].DisableKeyword("_EMISSION");
        	if(numbers[counter1, i] == 1){
        		mat1[i].EnableKeyword("_EMISSION");
        	}
        }
    }

    public void digit2(int num){
        counter2+=num;
        for(int i=0; i<7; i++){
            mat2[i].DisableKeyword("_EMISSION");
            if(numbers[counter2, i] == 1){
                mat2[i].EnableKeyword("_EMISSION");
            }
        }
    }

    public void digit3(int num){
        counter3+=num;
        for(int i=0; i<7; i++){
            mat3[i].DisableKeyword("_EMISSION");
            if(numbers[counter3, i] == 1){
                mat3[i].EnableKeyword("_EMISSION");
            }
        }
    }

    public void digit4(int num){
        counter4+=num;
        for(int i=0; i<7; i++){
            mat4[i].DisableKeyword("_EMISSION");
            if(numbers[counter4, i] == 1){
                mat4[i].EnableKeyword("_EMISSION");
            }
        }
    }


}
