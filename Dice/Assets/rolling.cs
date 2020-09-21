using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rolling : MonoBehaviour {
	public Rigidbody rg;
	public float pos;
	int ran,ran2,jump,r1,r2;
	float time;
	int[] ranlist = new int[] {-20,20};
	float[] ranlist2 = new float[] {-0.5f,0.5f};


	

	void Start () {
		rg = GetComponent<Rigidbody>();	
		jump = 0;
	}
	
	
	
	void Update () {
		time += Time.deltaTime;
		if(Input.GetKeyDown(KeyCode.Space)){
			// this.transform.position = new Vector3(pos,1f,-1f);	
			r1 = Random.Range(0,2);
			r2 = Random.Range(0,2);
			rg.AddForce(new Vector3(ranlist2[r1],10f,ranlist2[r2])*7f);
			ran = Random.Range(0,2);
			ran2 = Random.Range(0,2);
			rg.AddTorque(new Vector3(ranlist[ran],ranlist[ran2], 0) * 300f);
			jump = 1;

			
		}
		
	}

	void OnCollisionEnter(Collision other){
		// if(jump==1){
			// this.transform.position = new Vector3(-0.5f,1f,-1f);
		// 	jump = 0;
		// }
	}
}
