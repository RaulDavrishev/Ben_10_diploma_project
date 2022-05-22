using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Diamondhead : MonoBehaviour{

    public GameObject projectile;
    public Transform firePoint;
    float projectileSpeed = 200;
    public Transform crosshair;


    public Camera cam;
    Vector3 destination;


    void Update(){
        if(Input.GetMouseButton(1)){
            if(Input.GetMouseButtonDown(0)){
                    StartCoroutine(Timedelay());
            }
        }
    }


    void ShootProjectile(){

        Ray ray = cam.ViewportPointToRay(cam.ScreenToViewportPoint(crosshair.transform.position));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){
            destination = hit.point;
        }else{
            destination = ray.GetPoint(100);
        }
            InstantiateProjectile();
    }

    void InstantiateProjectile(){
        var ProjectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        ProjectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
        Destroy(ProjectileObj, 10f);
    }


    IEnumerator Timedelay(){
        yield return new WaitForSeconds(0.7f);
        ShootProjectile();
    }

}
