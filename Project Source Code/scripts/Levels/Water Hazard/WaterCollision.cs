using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour{

    public ParticleSystem ps;
    public List<ParticleCollisionEvent> ce;

    void Start(){
        ps = GetComponent<ParticleSystem>();
        ce = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other){

        if(other.gameObject.tag == "ice"){
            int num = ps.GetCollisionEvents(other, ce);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            int i = 0;

            while (i < num){
                if(rb != null){
                    Vector3 force = ce[i].velocity * 0.1f;
                    rb.AddForce(force);
                }
                i++;
            }
        }
    }
}
