using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Ghostfreak : MonoBehaviour{

    public CharacterController controller;
    public Transform cam;
    public GameObject punch;

    float speed = 15.0f;
    float jumpSpeed = 5.0f;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    float gravity = -3.0f;
    Vector3 velocity;
    float originalStepOffset;

    Animator anim;
    public AudioSource sounds;
    public AudioClip GhostModeIn;
    public AudioClip GhostModeOut;

    public Material texture;

    bool ghostMode;


    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();   
        originalStepOffset = controller.stepOffset;
    }



    void Update(){
        Movement();
        Punch();
        GhostMode();
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
        }

        if(!ghostMode){
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            if(controller.isGrounded && velocity.y<0){
                controller.stepOffset = originalStepOffset;
                velocity.y = -2.0f;
                if(Input.GetKey(KeyCode.Space)){
                    velocity.y = Mathf.Sqrt(jumpSpeed * gravity * -2.0f);
                }
            }else{
                controller.stepOffset = 0;
            }
        }   

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            anim.SetBool ("forward", true);  
        } 
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)){
            anim.SetBool ("forward", false);
            anim.SetBool ("faster", false);
        }  

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            anim.SetBool ("faster", true); 
            speed = 45.0f; 
        }else if(Input.GetKeyUp(KeyCode.LeftShift)){
            anim.SetBool ("faster", false); 
            speed = 15.0f; 
        } 
    }



    void Punch(){
        if(Input.GetMouseButtonDown(0)){
            anim.SetBool ("punch", true);
            punch.SetActive(true);
            StartCoroutine(PunchDelay());
        }
    }

    void GhostMode(){
        if(Input.GetMouseButtonDown(1)){
            sounds.PlayOneShot(GhostModeIn, 0.05f);
            StartCoroutine(GhostModeDelay(105.0f));
        }
        else if(Input.GetMouseButtonUp(1)){
            sounds.PlayOneShot(GhostModeOut, 0.05f);
            StartCoroutine(GhostModeDelay(3.15f)); 
        }

    }



    IEnumerator GhostModeDelay(float y){
        yield return new WaitForSeconds(0.5f);
        ghostMode = !ghostMode;
        controller.center = controller.center = new Vector3(0f, y, 0.23f);
        if(y == 15.0f || y == 105.0f){
            texture.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
        }else{
            texture.color = new Color(1.0f, 1.0f, 1.0f, 0.9f);
        }
    }



    IEnumerator PunchDelay(){
        yield return new WaitForSeconds(0.5f);
        anim.SetBool ("punch", false);
        punch.SetActive(false);
    }


}
