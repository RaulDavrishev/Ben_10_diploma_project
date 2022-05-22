using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_8 : MonoBehaviour{

    public GameObject canvas;
    public GameObject GreyMatter;

    public Animator anim;



    void OnTriggerEnter(Collider co){
        if(co.gameObject == GreyMatter){ canvas.SetActive(true); }
    }

    void OnTriggerExit(Collider co){
        canvas.SetActive(false);
    }

    void OnTriggerStay(Collider co){
        if(Input.GetKeyDown(KeyCode.E) && co.gameObject == GreyMatter){
            anim.SetBool("switch", true);
            canvas.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

}
