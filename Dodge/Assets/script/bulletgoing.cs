using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletgoing : MonoBehaviour {
	public Rigidbody rg;
	public Vector3 dir;
	public float speed,t;
	void Start () {
		randomDir();
		speed  = GameObject.Find("Director").GetComponent<GameDirector>().speed;		
		rg = GetComponent<Rigidbody>();	
		rg.AddForce(dir*speed);
	}
	
	void Update () {
		if(this.transform.position.x< -5.5f || this.transform.position.x>5.5f ||
			this.transform.position.z< -5.5f || this.transform.position.z>5.5f){
			Destroy(gameObject);
		}
		t+= Time.deltaTime;
		if(t>15f){
			if(this.gameObject != null){
				Destroy(gameObject);
			}
			t = 0;
		}

	}
	void randomDir(){
		if(this.transform.position.z>4f){
			dir = new Vector3(Random.Range(-1f,1f),0,-1);	
		}		
		else if(this.transform.position.z<-4f){
			dir = new Vector3(Random.Range(-1f,1f),0,1);	
		}		
		else if(this.transform.position.x>4f){
			dir = new Vector3(-1,0,Random.Range(-1f,1f));	
		}		
		else if(this.transform.position.x<-4f){
			dir = new Vector3(1,0,Random.Range(-1f,1f));	
		}		
	}
}
