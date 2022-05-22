using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour{

    float lookRadius = 70f;

    public Transform target;
    public NavMeshAgent agent;


    public AudioSource sounds;
    public AudioClip meow;

    bool one;


    void Update(){
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius){
            agent.SetDestination(target.position);
            if(!one){ StartCoroutine(MeowDelay()); one = true; }
            if(distance <= agent.stoppingDistance){
                FaceTarget();
            }
        }
    }

    void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    IEnumerator MeowDelay(){
        yield return new WaitForSeconds(3.0f);   
        sounds.PlayOneShot(meow, 0.1f); 
        one = false;
    }

}
