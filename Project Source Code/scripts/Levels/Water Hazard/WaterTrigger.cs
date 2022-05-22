using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour{

    public ScoreWaterHazard swh;

    public AudioSource sounds;

   void OnTriggerEnter(Collider co){
        if(co.gameObject.tag == "ice"){
            swh.Throw_ice();
            sounds.Play();
        }
   }


}
