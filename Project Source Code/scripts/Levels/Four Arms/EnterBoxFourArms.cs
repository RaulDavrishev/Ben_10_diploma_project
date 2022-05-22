using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBoxFourArms : MonoBehaviour{

    public ScoreFourArms sf;

    void OnTriggerEnter(Collider co){
            sf.Enter();
    }
}
