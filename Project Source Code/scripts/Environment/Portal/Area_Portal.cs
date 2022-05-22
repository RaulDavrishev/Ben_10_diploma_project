using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Area_Portal : MonoBehaviour{

    public Animator levelLoader;

    void OnTriggerEnter(Collider co){
        if(co.gameObject.tag == "Player"){
            levelLoader.SetTrigger("start");
            StartCoroutine(TimeDelay());
        }
    }


    IEnumerator TimeDelay(){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("FinishMenu");
    }

}
