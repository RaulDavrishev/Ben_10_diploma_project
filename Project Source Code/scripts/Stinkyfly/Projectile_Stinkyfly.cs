using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Stinkyfly : MonoBehaviour{

    public void OnTriggerEnter(Collider enemy){
        if(enemy.gameObject.tag=="enemy"){
            Destroy(enemy.gameObject);
        }
        Destroy(this.gameObject);
    }
}
