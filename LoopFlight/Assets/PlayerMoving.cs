using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public Rigidbody2D rg;
    public Vector3 dir,pos;
    public GameObject ball;
    private float time;
    private int charge;

    void Start()
    {
		rg = this.GetComponent<Rigidbody2D>();
		// ball = GameObject.Find("ball");
		charge = 0;
		time = 0;
    }

    
    void Update()
    {
    	pos = this.transform.position;

        if(Input.GetKey(KeyCode.RightArrow)){
        	this.transform.Translate(Vector2.right * 0.15f);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
        	this.transform.Translate(-Vector2.right * 0.15f);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
        	if(this.transform.position.y < -2.8f){
        		// this.transform.Translate(Vector2.up * Time.deltaTime * 20f);
        		rg.AddForce(new Vector2(0f,6f)*62f);
        	}
        	
        }
        if(Input.GetKey(KeyCode.Space)){
        	charge = 1;
        }
        time += Time.deltaTime;
        if(time > 1f){
        	time = 0;
        	charge = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D other){
    	
    	if(other.gameObject.tag == "ball"){
    		if(charge == 1){
    			Vector3 chargingdir =  new Vector3( (-pos.x+other.gameObject.transform.position.x) *40f, 0f,0f );
    			Debug.Log("charge! = "+chargingdir);
    			ball.GetComponent<Rigidbody2D>().AddForce(chargingdir *32f);
    			
    		}
    		
    	}
    }
}
