using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ScoreHeadblast : MonoBehaviour{
    
    public Animator levelLoader;

    public GameObject warning_message;
    public GameObject DoneCheckBox;
    public GameObject LevelCompleteCanvas;
    public GameObject LevelComplete5;

    public GameObject[] Character_models;
    public GameObject MainLevel;
    public GameObject HeadblastLevel;

    public GameObject Main_Level_Position;

    public HealthBar healthBar;
    public Animator bossAnim;
    public GameObject bossParticle;
    public GameObject bossScript;
    public NavMeshAgent bossAgent;
    public GameObject healthCanvas;

    public AudioSource sounds;
    public AudioClip dieSound;

    int BossHealth = 10;

    void Update(){

        if( BossHealth != 0 ){ warning_message.SetActive( !Character_models[5].activeSelf); }
        else{
            if(!LevelCompleteCanvas.activeSelf){ 
                sounds.PlayOneShot(dieSound, 1.0f); 
                bossAnim.SetBool("die", true);
                bossParticle.SetActive(false);
                bossScript.GetComponent<BossHeadblast>().enabled = false;
                bossAgent.enabled = false;
                healthCanvas.SetActive(false);
                DoneCheckBox.SetActive(true); 
                warning_message.SetActive(false);
                LevelCompleteCanvas.SetActive(true);
            }

            if(Input.GetKeyDown(KeyCode.E)){ 
                StartCoroutine(TimeDelay()); 
            } 
        }
        
    
    }


    public void health(){
        BossHealth -= 1;
        healthBar.SetHealth(BossHealth);
    }


    IEnumerator TimeDelay(){
        levelLoader.SetTrigger("start");
        yield return new WaitForSeconds(1.0f);
        LevelComplete5.SetActive(false);
        MainLevel.SetActive(true);
        HeadblastLevel.SetActive(false);
        for(int i=0; i<=10; i++){
            if(Character_models[i].activeSelf){
                Character_models[i].SetActive(false);
                Character_models[i].transform.position = Main_Level_Position.transform.position;
                Character_models[i].SetActive(true);
            } 
        }
    }







}
