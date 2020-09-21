using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class check : MonoBehaviour
{	
	
   	public int time,jump; 
   	public GameObject dice,Director;
   	
    void Start()
    {
     	jump=0;
     	Director = GameObject.Find("Director");
    }

   
    void Update()
    {	
    	if(Input.GetKey(KeyCode.Space)){
    		jump = 1;
    		Director.GetComponent<Director>().dicesum=0;
    		Director.GetComponent<Director>().stop_dicenum=0;
    	}

    	if(this.transform.position.y<0.4f && jump == 1){
	    	if(dice.GetComponent<Rigidbody>().velocity.x == 0 &&
	    		dice.GetComponent<Rigidbody>().velocity.y == 0 &&
	    		dice.GetComponent<Rigidbody>().velocity.z == 0){
	    			// Debug.Log(gameObject);   	
	    			Director.GetComponent<Director>().dicesum+=int.Parse(gameObject.name);
	    			Director.GetComponent<Director>().stop_dicenum++;
	    			jump=0;
	    	}
	    }
    	// if(){
    	// 	Debug.Log(gameObject);   
    	// }
    	
        
        
        

        if(Input.GetKey(KeyCode.W)){
        	Debug.Log(gameObject+" : "+this.transform.position.y);   
        }
    }
    
}
