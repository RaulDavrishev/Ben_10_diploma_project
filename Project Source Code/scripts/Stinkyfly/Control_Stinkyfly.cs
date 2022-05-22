using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Stinkyfly : MonoBehaviour{

    public CharacterController controller;
    public Transform cam;
    public GameObject punch;
    public GameObject crosshair;

    float speed = 42.0f;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 velocity;
    float originalStepOffset;

    Animator anim;

    public AudioSource sounds;
    public AudioClip punch_sound;


    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
        originalStepOffset = controller.stepOffset;
    }



    void Update(){
        Movement();
        aimAndShoot();
        Punch();
        heighControl();
    }



    void Movement(){

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal,0,vertical).normalized;

        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            if(controller.isGrounded){
                controller.stepOffset = originalStepOffset;
            }else{
                controller.stepOffset = 0;
            }
        }



        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            anim.SetBool ("forward", true);  
        } 
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)){
            anim.SetBool ("forward", false);
        }  

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed = 100.0f; 
        }else if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = 42.0f; 
        } 

    }



    void heighControl(){
        controller.Move(velocity * Time.deltaTime);
        if(Input.GetKey(KeyCode.Space)){
            velocity.y += 0.3f;
        }
        else if(Input.GetKey(KeyCode.C)){
            velocity.y -= 0.3f;
        }else{
            velocity.y = 0; 
        }
    }



    void aimAndShoot(){

        if(Input.GetMouseButtonDown(1)){ crosshair.SetActive(true); }
        else if(Input.GetMouseButtonUp(1)){ crosshair.SetActive(false); }
        if(Input.GetMouseButtonDown(0) && crosshair.activeSelf){ anim.SetBool ("shoot", true);}
        else if(Input.GetMouseButtonUp(0)){ anim.SetBool ("shoot", false); } 

    }

    void Punch(){
        if(Input.GetMouseButtonDown(0) && !(Input.GetMouseButton(1))){
            anim.SetBool ("punch", true);
            sounds.PlayOneShot(punch_sound, 0.1f);
            punch.SetActive(true);
            StartCoroutine(Timedelay());
        }
    }


    IEnumerator Timedelay(){
        yield return new WaitForSeconds(0.5f);
        anim.SetBool ("punch", false);
        punch.SetActive(false);
    }


}
