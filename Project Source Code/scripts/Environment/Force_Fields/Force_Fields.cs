using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force_Fields : MonoBehaviour{

    public AudioSource sounds;
    public AudioClip PowerDown;
    
    public GameObject[] force_field;
    public GameObject[] console_area;
    public GameObject[] console;
    public Material console_material;

    bool[] once = {false,false,false,false,false,false,false,false,false,false};

    void Update(){
        for( int i=0; i<10; i++ ){
            if(!force_field[i].activeSelf && !once[i]){
                force_field[i].SetActive(true);
                console_area[i].SetActive(false);
                console[i].GetComponent<Renderer>().material = console_material;
                StartCoroutine(TimeDelay(i));
                once[i] = true;
            }
        }

    }

    IEnumerator TimeDelay(int i){
        yield return new WaitForSeconds(1.65f);
        sounds.PlayOneShot(PowerDown, 0.75f);
        yield return new WaitForSeconds(0.35f);
        force_field[i].SetActive(false);
    }

}
