using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBox : MonoBehaviour{

    public ScoreGhostfreak sc;

    void OnTriggerEnter(Collider co){
            sc.Enter();
    }
}
