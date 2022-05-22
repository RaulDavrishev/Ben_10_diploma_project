using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Transformation : MonoBehaviour{

    public ParticleSystem ps;
    public GameObject[] Character_models;

    void Update(){
        if(ps.isPlaying){
            for(int i=0; i<= 10; i++){
                if(Character_models[i].activeSelf){
                    transform.position = Character_models[i].transform.position;
                }
            }
        }
    }



}
