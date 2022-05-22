using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour{

    public Animator anim;

    public AudioSource sounds;
    public AudioClip coin;

    public GameObject[] omnicoins;
    public Material[] door_light_mat;


    bool[] state = {true, true, true, true, true, true, true, true, true, true, true};

    int count = 0;

    void Start(){
        for( int i=0; i<10; i++ ){
            door_light_mat[i].DisableKeyword("_EMISSION");
        }

    }    
    
    void FixedUpdate(){

        for( int i=0; i<10; i++ ){
            if( !omnicoins[i].activeSelf && state[i] ){
                state[i] = false;
                door_light_mat[i].EnableKeyword("_EMISSION");
                count += 1;
                sounds.PlayOneShot(coin, 0.1f);
            }
        }

        if( count == 10 && state[10] ){
            anim.SetBool("open", true);
            sounds.Play();
            state[10] = false;
        }

        if( Input.GetKeyDown(KeyCode.L) ){
            anim.SetBool("open", true);
            sounds.Play();
            state[10] = false;
        }

 
    }



}
