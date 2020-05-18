using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallvibe : MonoBehaviour {
	public int tmplvl;
	public float speed; //이동속도
	public int flag = -1; //0:left , 1=center, 2=right
	int wait_time;
	public float timer;
	void Start () {
		timer = 0.0f;
		wait_time = 4;
		speed=15f;
		//스피드 점점 증가하게 하려면 다 고쳐야함;;
	}
	void Update () {
		
		float moving = Time.deltaTime * speed;
		gameObject.transform.Translate( Vector3.right * moving);
		
		// 좌우 이동 기능
		// Vector3 v = pos;
	 //    v.x += delta * Mathf.Sin(Time.time * speed);
	 //    gameObject.transform.position = v;
		timer += Time.deltaTime;

	  	if(gameObject.transform.position.z < -1){
	  		Destroy(gameObject);
	  	}
	  	
	}
	void OnTriggerEnter(Collider other){		
		

		flag = GameObject.FindGameObjectWithTag("caltext").GetComponent<Calculatenum>().whereisanswer();
		
		if(flag == 0){
			if( gameObject.tag=="Huddle" && other.tag == "Player"){
				Destroy(gameObject);
				clearall();
			}
		}
		else if(flag == 1){
			if( gameObject.tag=="Huddle2" && other.tag == "Player"){
				Destroy(gameObject);
				clearall();
			}
		}
		else if(flag == 2){
			if( gameObject.tag=="Huddle3" && other.tag == "Player"){
				Destroy(gameObject);
				clearall();
			}
		}		
		else{
			GameObject.FindGameObjectWithTag("Player").transform.Translate(Vector3.back * 0.8f);
		}
	}
	//답맞추고 화이트보드처리
	public void clearall(){
		GameObject.FindGameObjectWithTag("caltext").GetComponent<Calculatenum>().change();
			GameObject.FindGameObjectWithTag("caltext").GetComponent<Calculatenum>().txtobj.text = "";
			GameObject.FindGameObjectWithTag("caltext").GetComponent<Calculatenum>().lefttxt.text = "";
			GameObject.FindGameObjectWithTag("caltext").GetComponent<Calculatenum>().centertxt.text = "";
			GameObject.FindGameObjectWithTag("caltext").GetComponent<Calculatenum>().righttxt.text = "";
	}
}
