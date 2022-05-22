using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button3_1 : MonoBehaviour{

    public GameObject Upgrade;
    public GameObject canvas;
    public Animator anim;
    public AudioSource click;
    public Material mat;
    public ScoreUpgrade su;
    bool pressed;
    int num = 3;



    void Start(){
        mat.DisableKeyword("_EMISSION");
    }


    void OnTriggerEnter(Collider co){
        if(co.gameObject == Upgrade){ canvas.SetActive(true); }
    }

    void OnTriggerExit(Collider co){
        canvas.SetActive(false);
    }

    void OnTriggerStay(Collider co){
        if(Input.GetKeyDown(KeyCode.E) && co.gameObject == Upgrade){
            pressed =! pressed;
            anim.SetBool("press", pressed);
            click.Play();

            if(pressed){ mat.EnableKeyword("_EMISSION"); su.digit3(num); }
            else{mat.DisableKeyword("_EMISSION"); su.digit3(-num); }
            
        }
    }

}
