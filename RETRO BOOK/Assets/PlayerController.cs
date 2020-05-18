using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Rigidbody pr_rg;
	public float speed= 8f;	
	void Start () {
		pr_rg = GetComponent<Rigidbody>();
	}
	
	void Update () {
		float xInput = Input.GetAxis("Horizontal");
		float zInput = Input.GetAxis("Vertical");

		float xSpeed = xInput * speed;
		float zSpeed = zInput * speed;

		Vector3 newVelocity = new Vector3(xSpeed,0f,zSpeed);
		pr_rg.velocity = newVelocity;


		// if(Input.GetKey(KeyCode.UpArrow) == true){
		// 	pr_rg.AddForce(0f,0f,speed);
		// }
		// if(Input.GetKey(KeyCode.DownArrow) == true){
		// 	pr_rg.AddForce(0f,0f,-speed);
		// }
		// if(Input.GetKey(KeyCode.LeftArrow) == true){
		// 	pr_rg.AddForce(-speed,0f,0f);
		// }
		// if(Input.GetKey(KeyCode.RightArrow) == true){
		// 	pr_rg.AddForce(speed,0f,0f);
		// }
	}
	public void Die(){
		gameObject.SetActive(false);
	}
	// public void OnCollisionEnter(Collision other){
	// 	if( other.gameObject.tag == "wall"){
	// 		Debug.Log("!!!");
	// 	}
	// }
}
