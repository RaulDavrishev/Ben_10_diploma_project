using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour{
    
    public ScoreHeadblast sc;


    void OnTriggerEnter(Collider co){
        if(co.gameObject.tag=="Bullet"){
            sc.health();
        }
    }
}
