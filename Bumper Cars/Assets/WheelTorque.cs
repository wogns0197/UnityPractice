using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTorque : MonoBehaviour {
	float xSpeed=1f,rotSpeed=10f;
	public Rigidbody rg;
	private Quaternion Left = Quaternion.identity;

	void Start () {
		rg = GetComponent<Rigidbody>();
	}
	
	void Update () {
		float xInput = Input.GetAxis("Vertical");
		float yInput = Input.GetAxis("Horizontal");
		if(xInput>0){xSpeed += 0.1f;}
		else if(xInput<0){xSpeed +=  -0.1f;}
		else{xSpeed /= 1.5f;}
		
		
		this.transform.Rotate(0f,xSpeed,0f);
		
		// if(yInput<0){
		// 	transform.rotation = Quaternion.Slerp(transform.rotation, Left, Time.deltaTime * 5.0f);
		// }
		// else if(yInput>0){
		// 	// this.transform.rotation = Quaternion.Lerp(this.transform.rotation, 
		// 	// 	Quaternion.Euler(this.transform.rotation.x ,20f,this.transform.rotation.z),
		// 	// 	 rotSpeed * Time.deltaTime);	
		// }
	}

}
