using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    public Rigidbody2D rg;
    private Vector3 pos, dir;
    void Start()
    {
		rg = this.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        pos = this.transform.position;
    }

    void OnCollisionEnter2D(Collision2D other){
    	
    	if(other.gameObject.tag == "ground"){
    		rg.AddForce(new Vector2(0,4f) *122f);
    	}
    	if(other.gameObject.tag == "wall"){
    		
    		dir = pos-other.gameObject.transform.position;
    		if(dir.x > 0){
    			rg.AddForce(new Vector2(3f,0) *122f);	
    		}
    		else{
    			rg.AddForce(new Vector2(-3f,0) *122f);		
    		}

    	}

    	if(other.gameObject.tag == "player"){
    		dir = pos-other.gameObject.transform.position + new Vector3(0f,2f,0f);
    		// Debug.Log(dir);
    		rg.AddForce(dir *122f);
    	}
    }
}
