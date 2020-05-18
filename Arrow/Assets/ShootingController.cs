using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class ShootingController : MonoBehaviour {
	public GameObject arrow,bow;
	public Rigidbody rg;
	Vector3 pos,bow_pos;
	public float gage=0,Xvec,Yvec,Xscala=0,Yscala=0;
	public bool isShoot=false;
	

	void Start () {
		bow = GameObject.Find("Bow");
		rg = GetComponent<Rigidbody>();
		pos = this.transform.position;
		bow_pos = bow.transform.position;
	}
	
	void Update () {
		//방향 부분
		Xvec = Input.GetAxis("Horizontal");
		Yvec = Input.GetAxis("Vertical");
		if(rg.velocity.z <= 0){
			if(Xvec <0 ){
				Xscala -= 0.2f;
				transform.eulerAngles = new Vector3(260f-Yscala,Xscala,0f);
				bow.transform.position = new Vector3(bow.transform.position.x -0.001f,bow_pos.y,bow_pos.z);
			}
			else if(Xvec>0){
				Xscala += 0.2f;
				transform.eulerAngles = new Vector3(260f-Yscala,Xscala,0f);	
				bow.transform.position = new Vector3(bow.transform.position.x +0.001f,bow_pos.y,bow_pos.z);
			}
			if(Yvec<0){
				Yscala -= 0.2f;
				bow.transform.eulerAngles = new Vector3(0f,270f,120f + Yscala);
				transform.eulerAngles = new Vector3(260f-Yscala,Xscala,0f);
			}
			else if(Yvec>0){
				Yscala += 0.2f;
				bow.transform.eulerAngles = new Vector3(0f,270f,120f + Yscala);	
				transform.eulerAngles = new Vector3(260f-Yscala,Xscala,0f);
			}
		}

		//발사 부분
		if(Input.GetKey(KeyCode.Space)){
			gage += Time.deltaTime*30;
			this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-Time.deltaTime/16, this.transform.position.z - Time.deltaTime/8);
			Vector3.Lerp(pos, new Vector3(pos.x,pos.y,pos.z-3f),Time.deltaTime);	

		}
		else if(Input.GetKeyUp(KeyCode.Space)){
			rg.useGravity = true;
			rg.AddForce(new Vector3(Xscala/2, 8f+Yscala, 20f)*gage );
			isShoot = true;
			gage = 0f;
			rg.AddTorque(new Vector3(0f,20f,0f)*100f);
		}
		
		if(this.transform.position.y >70f){
			Destroy(gameObject);
		}
		
	}
	void OnCollisionEnter(Collision other){
		
		if(other.gameObject.CompareTag("wall")){
			GameObject.Find("ArrowGen").GetComponent<ArrowGen>().ArrowGenerator();
			Destroy(gameObject);
		}
		else if(other.gameObject.CompareTag("target")){
			rg.velocity = Vector3.zero;
			rg.isKinematic = true;			
			Thread.Sleep(1500);
			Destroy(gameObject);
			GameObject.Find("ArrowGen").GetComponent<ArrowGen>().ArrowGenerator();
		}
		isShoot = false;
		bow.transform.position = bow_pos;
	}

	


}
