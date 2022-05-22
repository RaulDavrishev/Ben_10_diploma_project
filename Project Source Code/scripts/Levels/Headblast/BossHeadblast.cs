using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossHeadblast : MonoBehaviour{

    float lookRadius = 200f;

    public Transform target;
    public NavMeshAgent agent;

    public Animator anim;

    public AudioSource sounds;
    public AudioClip voice;
    public AudioClip voice2;

    bool[] one = {false,false};


    void Update(){
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius){
            anim.SetBool("walking", true);
            if(!one[0]){sounds.PlayOneShot(voice, 0.4f); one[0] = true;}
            agent.SetDestination(target.position);
            if(distance <= agent.stoppingDistance){ 
                if(!one[1]){ anim.SetBool("attack", true); sounds.PlayOneShot(voice2, 0.4f); one[1] = true;}
                else{
                    anim.SetBool("attack", false);
                }
            }else{
                anim.SetBool("attack", false);
                one[1] = false;
            }
        }else{
            anim.SetBool("walking", false);
            one[0] = false;
        }
    }

}
