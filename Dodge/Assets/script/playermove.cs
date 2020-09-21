using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class playermove : MonoBehaviour {
	// Rigidbody rg;
	public float speed;
	
	void Start () {
		// rg = GetComponent<Rigidbody>();
		speed = 5f;
	}
	
	
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow)){transform.Translate(Vector3.right * speed* Time.deltaTime);}
		else if(Input.GetKey(KeyCode.LeftArrow)){transform.Translate(Vector3.left *speed* Time.deltaTime);}
		if(Input.GetKey(KeyCode.UpArrow)){transform.Translate(Vector3.forward * speed* Time.deltaTime);}
		else if(Input.GetKey(KeyCode.DownArrow)){transform.Translate(Vector3.forward*(-1f) *speed* Time.deltaTime);}



	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "bullet"){
			
			SceneManager.LoadScene("start");
	
		}
	}
}
