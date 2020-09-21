using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public Rigidbody rg;
    public Animator ani;
    public GameObject camera;
	float speed,t;

    void Start()
    {	
    	rg = this.gameObject.GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        camera = GameObject.Find("Main_Camera");
    	speed = 0.3f;
    }
    // speed = 0.1 , right_left = 0.4 , jump = 7f;
    void Update()
    {   

        //------Player Moving------------------------------
     	if(Input.GetKey(KeyCode.UpArrow)){
     		this.transform.Translate(new Vector3(0,0,0.1f)*speed);
            // cameraReset();
            ani.SetBool ("isWalking", true );    
     	}
        else if(Input.GetKeyUp(KeyCode.UpArrow)){
            ani.SetBool ("isWalking", false);

        }
     	if(Input.GetKey(KeyCode.DownArrow)){
     		this.transform.Translate(new Vector3(0,0,-0.1f)*speed);
     	}   
     	if(Input.GetKey(KeyCode.RightArrow)){
            this.transform.Rotate(new Vector3(0,0.7f,0));
            
     	}   
     	if(Input.GetKey(KeyCode.LeftArrow)){
            this.transform.Rotate(new Vector3(0,-0.7f,0));
            
     	}   
        //---------Camera Moving---------------------------------
        if(Input.GetKey(KeyCode.Q)){
            camera.transform.RotateAround( this.transform.position, new Vector3(0,-0.6f,0), 1f);
        }   
        if(Input.GetKey(KeyCode.E)){
            camera.transform.RotateAround( this.transform.position, new Vector3(0,0.6f,0), 1f);
        }   
        if(Input.GetKey(KeyCode.W)){
            camera.transform.RotateAround( this.transform.position, new Vector3(0.4f,0,0), 1f);
        }   
        if(Input.GetKey(KeyCode.S)){
            camera.transform.RotateAround( this.transform.position, new Vector3(-0.4f,0,0), 1f);
        }   

        if(Input.GetKey(KeyCode.A)){
            ani.SetTrigger("isHi");
        }   
     	else if(Input.GetKey(KeyCode.Space)){
            ani.SetBool ("isJumping", true );
     		rg.AddForce(new Vector3(0,5f,0)*12f);
     	}   
        // if(rg.velocity.y>0){
                
        // }
        if(rg.velocity.y<0){
            ani.SetBool ("isJumping", false );    
        }
        // t+= Time.deltaTime;
        // if(t>1){
        //     t=0;
        //     Debug.Log("x = " + camera.transform.rotation.x+ " y = " + camera.transform.rotation.y + " z = "+ camera.transform.rotation.z);
        // }
        
        
    }
    // void cameraReset(){
        
    //     camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.Euler(20f,0,0) , Time.time * speed);
    // }

}
