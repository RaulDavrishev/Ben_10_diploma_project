using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour{

    public GameObject Stinkyfly;

    public void OnTriggerEnter(Collider co){
        if(co.gameObject == Stinkyfly){ StartCoroutine(TimeDelay()); }  
    }

    IEnumerator TimeDelay(){
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }

}
