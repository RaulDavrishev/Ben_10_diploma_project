using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_5 : MonoBehaviour{

    public Animator levelLoader;

    public GameObject canvas;

    public GameObject[] Character_models;

    public GameObject MainLevel;
    public GameObject HeadblastLevel;

    public GameObject Headblast_Level_Position;

    void OnTriggerEnter(Collider co){
        if(co.gameObject.tag == "Player"){
            canvas.SetActive(true);
        }
    }

    void OnTriggerExit(Collider co){
        canvas.SetActive(false);
    }

    void OnTriggerStay(Collider co){
        if(Input.GetKeyDown(KeyCode.E)){
            levelLoader.SetTrigger("start");
            StartCoroutine(TimeDelay());
            canvas.SetActive(false);
        }
    }

    IEnumerator TimeDelay(){
        yield return new WaitForSeconds(1.0f);
            MainLevel.SetActive(false);
            HeadblastLevel.SetActive(true);
            for(int i=0; i<=10; i++){
                if(Character_models[i].activeSelf){
                    Character_models[i].SetActive(false);
                    Character_models[i].transform.position = Headblast_Level_Position.transform.position;
                    Character_models[i].SetActive(true);
                } 
            }
    }


}