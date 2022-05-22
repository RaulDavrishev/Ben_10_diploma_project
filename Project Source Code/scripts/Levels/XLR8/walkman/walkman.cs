using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkman : MonoBehaviour{

    public void OnTriggerEnter(Collider co){
        this.gameObject.SetActive(false);
    }
}
