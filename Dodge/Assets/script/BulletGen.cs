using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGen : MonoBehaviour {
	public GameObject bullet;
	float t,speed,minus;
	public float count;
	public Vector3 dir;
	public int level;
	void Start () {
		t=2;
		speed =78f;
		minus = 1f;
		count = 3f;
	}
	// 생성위치에서의 반대 포지션으로 dir 잡고 발사시키기
	// 속도 , z & x 축 random --> 범위 안에서
	void Update () {
		count = GameObject.Find("Director").GetComponent<GameDirector>().count;
		
		if(this.name == "BulletGenerator_top" || this.name == "BulletGenerator_bottom" ){
			this.transform.Translate(new Vector3(minus,0,0)*2f *Time.deltaTime);
			if(this.transform.position.x>5f || this.transform.position.x<-5f){
				minus *= -1;
			}
		}
		else if(this.name == "BulletGenerator_right" || this.name == "BulletGenerator_left" ){
			this.transform.Translate(new Vector3(0,0,minus) *2f* Time.deltaTime);	
			if(this.transform.position.z>5f || this.transform.position.z<-5f){
				minus *= -1;
			}
		}
		t += Time.deltaTime;
		if(t >count){
			t =0;
			Instantiate(bullet, this.transform.position, this.transform.rotation);
			// bullet.GetComponent<Rigidbody>().AddForce(dir*speed);
			// 아아 생성후 rg 못건드림!!!!!
		}			
	}
	// void OnCollisionEnter(Collision other){	
	// 	if(other.gameObject.tag == "wall"){
	// 		minus*=-1;
	// 		Debug.Log("!@#!@#");
	// 	}
	// }
	
}
