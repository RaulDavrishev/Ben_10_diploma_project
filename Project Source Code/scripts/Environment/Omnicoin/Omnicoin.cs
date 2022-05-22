using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omnicoin : MonoBehaviour{

    public void OnTriggerEnter(Collider coin){
        this.gameObject.SetActive(false);
    }
}
