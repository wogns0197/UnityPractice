using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour {
	float dtime = 2f,d=0f,xSpeed;
	Rigidbody rg;
	public GameObject rear;
	Vector3 dir ;
	void Start () {
		rg = GetComponent<Rigidbody>();

	}

	void Update () {
		// Debug.Log(this.transform.position - rear.transform.position);
		rear.transform.position = new Vector3(this.transform.position.x,
			this.transform.position.y,this.transform.position.z-5);
		dir = this.transform.position - rear.transform.position;
		// Debug.Log(dir);
		d += Time.deltaTime;
		if(dtime<d){
			d =0f;			
		}		
		if(Input.GetKey(KeyCode.UpArrow)){			
			// rg.AddForce(new Vector3(0f,0f,3f)*70f);
			rg.AddForce(dir*70f);
			if(rg.velocity.z > 40f){
				rg.AddForce(new Vector3(0f, 2f, 0f)*70f);	
				// rg.transform.eulerAngles = new Vector3(rg.transform.eulerAngles.x-0.3f,
				// 	rg.transform.eulerAngles.y,rg.transform.eulerAngles.z);
				
				
			}
		}
		xSpeed = Input.GetAxis("Horizontal");
		// if(this.transform.position.y >3f){
		rg.AddForce( new Vector3(xSpeed*2f, 0f, 0f)*50f);
		rg.transform.eulerAngles = new Vector3(rg.transform.eulerAngles.x,
				rg.transform.eulerAngles.y + xSpeed*0.3f,rg.transform.eulerAngles.z- xSpeed*0.6f);
		// }

	}
}
