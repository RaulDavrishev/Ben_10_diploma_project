using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour{

    public Animator anim;
    public AudioSource sounds;
    public ParticleSystem TransformationFX;

    public AudioClip open_UI_sound, select, transformation;

    public GameObject[] UI_Images;
    public GameObject[] Character_models;

    public AudioClip[] Voices;

    int number = 1;
    int current, next = 0;
    bool state_UI;

    bool[] UI = {true,true,false,false,false,false,false,false,false,false,false};



    void Update(){
        SelectCharacter();
    }



    void Transformate(){

        current = next;
        next = number;
        if(current == number){ next = 0; }

        Character_models[next].transform.position = Character_models[current].transform.position;
        Character_models[next].transform.rotation = Character_models[current].transform.rotation;
        Character_models[current].SetActive(false);
        Character_models[next].SetActive(true);

        TransformationFX.Play();
        sounds.PlayOneShot(transformation, 0.5f);
        StartCoroutine(VoiceDelay());

    }



    void SelectCharacter(){

        if(Input.GetMouseButtonDown(2)){ 
            if(state_UI == false){ 
                state_UI = true; 
                UI[0] = true; 
                sounds.PlayOneShot(open_UI_sound, 0.3f);
            }
            else{ 
                state_UI = false;
                for (int i = 0; i < 10; i++){ UI_Images[i].SetActive(false); } 
                if(next == 0){ anim.SetBool("transformation", true); StartCoroutine(TransformationDelay()); }
                else{ Transformate(); } 
            }
        }

        if(state_UI){
            if( Input.GetAxis("Mouse ScrollWheel") > 0 ){ number+=1; if( number > 10 ){ number = 1; } }
            if( Input.GetAxis("Mouse ScrollWheel") < 0 ){ number-=1; if( number < 1 ){ number = 10; } }
            if( Input.GetAxis("Mouse ScrollWheel") != 0 || UI[0]){
                UI[0] = false;
                sounds.PlayOneShot(select, 0.55f); 
                for (int i = 1; i <= 10; i++){ UI[i] = false; }  
                UI[number] = true;
                for (int i = 0; i < 10; i++){ UI_Images[i].SetActive(UI[i+1]); } 
            }
        }

  
    }


    IEnumerator TransformationDelay(){
        sounds.PlayOneShot(Voices[0], 1.8f);
        yield return new WaitForSeconds(0.9f);
        Transformate();
        anim.SetBool("transformation", false);
    }

    IEnumerator VoiceDelay(){
        yield return new WaitForSeconds(0.7f);

        switch(next){
            case 1: sounds.PlayOneShot(Voices[1], 0.7f); break;
            case 2: sounds.PlayOneShot(Voices[2], 0.4f); break;
            case 3: sounds.PlayOneShot(Voices[3], 0.45f); break;
            case 4: sounds.PlayOneShot(Voices[4], 0.6f); break;
            case 5: sounds.PlayOneShot(Voices[5], 0.25f); break;
            case 6: sounds.PlayOneShot(Voices[6], 0.6f); break;
            case 7: sounds.PlayOneShot(Voices[7], 0.45f); break;
            case 8: sounds.PlayOneShot(Voices[8], 0.4f); break;
            case 9: sounds.PlayOneShot(Voices[9], 0.5f); break;
            case 10: sounds.PlayOneShot(Voices[10], 0.3f); break;
        }
    }

        



}
