using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smell : MonoBehaviour{

    void OnTriggerEnter(Collider co){
        this.gameObject.SetActive(false);
    }
    
}
