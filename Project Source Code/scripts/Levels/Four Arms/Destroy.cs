using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour{

    public GameObject destroyed;

    void OnTriggerEnter(Collider co){
        if(co.gameObject.tag == "FourArmsPunch"){
            Instantiate(destroyed, transform.position, transform.rotation);
            StartCoroutine(TimeDelay());
        }
    }

    IEnumerator TimeDelay(){
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }



}
