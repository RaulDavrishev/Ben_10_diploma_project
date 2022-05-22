using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch_XLR8 : MonoBehaviour{

    public void OnTriggerEnter(Collider enemy){
        if(enemy.gameObject.tag=="enemy"){
            Destroy(enemy.gameObject);
        }
    }
}
