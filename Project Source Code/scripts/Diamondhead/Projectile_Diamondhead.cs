using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Diamondhead : MonoBehaviour{

    public void OnTriggerEnter(Collider enemy){
        if(enemy.gameObject.tag=="enemy"){
            Destroy(enemy.gameObject);
        }
        if(enemy.gameObject.tag=="crystal"){
            enemy.gameObject.SetActive(false);
        }
        Destroy(this.gameObject);
    }
}
