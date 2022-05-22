using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_XLR8 : MonoBehaviour{

    public CharacterController controller;
    public Transform cam;
    public GameObject punch;

    public AudioSource sounds;
    public AudioClip StartSpeed;
    public GameObject SpeedFX;

    float speed = 21.0f;
    float jumpSpeed = 4.0f;

    float gravity = -30.0f;
    Vector3 velocity;
    float originalStepOffset;

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Animator anim;



    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
        originalStepOffset = controller.stepOffset;
    }



    void Update(){
        Movement();
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

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(controller.isGrounded && velocity.y<0){
            controller.stepOffset = originalStepOffset;
            velocity.y = -2.0f;
            if(Input.GetKeyDown(KeyCode.Space)){
                anim.SetBool ("jump", true);
                velocity.y = Mathf.Sqrt(jumpSpeed * gravity * -2.0f);
                StartCoroutine(JumpDelay());
            }
            if(Input.GetMouseButtonDown(0) && !(Input.GetMouseButton(1))){
                anim.SetBool ("punch", true);
                StartCoroutine(PunchDelay());
            }
        }else{
            controller.stepOffset = 0;
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            anim.SetBool ("walking", true);  
        } 
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)){
            anim.SetBool ("running", false);
            anim.SetBool ("walking", false);
            SpeedFX.SetActive(false);
        }  
        if(Input.GetKeyDown(KeyCode.LeftShift)){ anim.SetBool ("running", true); speed = 300.0f; sounds.Play(); SpeedFX.SetActive(true); sounds.PlayOneShot(StartSpeed, 0.4f); }
        else if(Input.GetKeyUp(KeyCode.LeftShift)){ anim.SetBool ("running", false); speed = 21.0f; sounds.Stop(); SpeedFX.SetActive(false); }         

    }

    IEnumerator JumpDelay(){
        yield return new WaitForSeconds(0.1f);
        anim.SetBool ("jump", false);
    }

    IEnumerator PunchDelay(){
        yield return new WaitForSeconds(0.3f);
        punch.SetActive(true);
        anim.SetBool ("punch", false);
        yield return new WaitForSeconds(1.0f);
        punch.SetActive(false);
    }


}
