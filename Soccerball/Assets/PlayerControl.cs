using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl: MonoBehaviour {
	public Rigidbody rg;
	public GameObject ball,particle,burst;
	public float speed= 8f, rotSpeed = 50f,xInput,zInput,sht_gage=0f,dtime=0f;
	public Vector3 newVelocity;
	public bool shoot=false;

	void Start () {
		rg = GetComponent<Rigidbody>();
		burst = GameObject.Find("burst");
	}
	
	void Update () {
		dtime += Time.deltaTime;
		xInput = Input.GetAxis("Horizontal");
		zInput = Input.GetAxis("Vertical");
		float xSpeed = xInput * speed;
		float zSpeed = zInput * speed;
		if(Input.GetKey(KeyCode.Z)){speed=14f;}
		else{speed= 8f;}

		//슈팅 게이지 및 공과 충돌 전 슈팅판정 !!!가장중요한코드!!
		if(Input.GetKeyDown(KeyCode.X)){
			shoot = true;
			sht_gage = 0.8f;
			dtime = 0f;
		}
		else{
			if(dtime>sht_gage){
				shoot = false;
				sht_gage = 0f;
				dtime=0f;
			}
		}
		// Debug.Log("dtime = "+dtime+" sht_gage = "+sht_gage+shoot);
		//--------------------------------------------
		
		Vector3 newVelocity = new Vector3(xSpeed,0f,zSpeed);
		rg.velocity = newVelocity;
		
		//방향키 방향으로 서서히 rotate
		//rotation값은 임의로 수정이 불가능 --> Vector로 취급 안함, Euler로 변환필요
		if(xInput<0){ this.transform.rotation=Quaternion.Lerp(
			this.transform.rotation,Quaternion.Euler(0f, -10f,0f)
			,rotSpeed * Time.deltaTime );}
		else if(xInput>0){ this.transform.rotation=Quaternion.Lerp(
			this.transform.rotation,Quaternion.Euler(0f, -190f,0f)
			,rotSpeed * Time.deltaTime );}
		if(zInput<0){this.transform.rotation=Quaternion.Lerp(
			this.transform.rotation,Quaternion.Euler(0f, -100f,0f)
			,rotSpeed * Time.deltaTime );}
		else if(zInput>0){this.transform.rotation=Quaternion.Lerp(
			this.transform.rotation,Quaternion.Euler(0f, 80f,0f)
			,rotSpeed * Time.deltaTime );}
		

		burst.transform.position = ball.transform.position;
		//슈팅 이펙트 공 따라가

	}
	void OnCollisionEnter(Collision collision){	
    	Vector3 smoothpos;
    	Vector3 torq = new Vector3(0f,0f,0f);
    	if(collision.gameObject.CompareTag("ball")){
  			var contact = collision.contacts[0];
  			Vector3 pos = contact.point - transform.position + new Vector3(0f,0.5f,0f);
  			//플레이어 중심에서 공 contact 지점을 상대좌표로 계산

  			//드리블시 회전 토크는 반대방향
  			if(pos.x>0){torq.x=-30;}
			else{ torq.x=30;}
			if(pos.z>0){ torq.z=-30;}
			else{ torq.z=30;}
			ball.GetComponent<Rigidbody>().AddTorque(torq * 500);
			// Debug.Log("pos : "+pos);    
  	// 		Debug.Log("torq : "+torq);    
  			
			if(shoot){
				
				
				burst.GetComponent<ParticleSystem>().Play();

				float xInput = Input.GetAxis("Horizontal");
				float zInput = Input.GetAxis("Vertical");  				
				smoothpos = new Vector3(2*xInput,pos.y+1.5f,2*zInput);
				ball.GetComponent<Rigidbody>().AddForce((smoothpos ) * 800);  					
			}
			else{
				if(Input.GetKey(KeyCode.X)){
					burst.GetComponent<ParticleSystem>().Play();

					float xInput = Input.GetAxis("Horizontal");
					float zInput = Input.GetAxis("Vertical");  				
					smoothpos = new Vector3(2*xInput,pos.y+1.5f,2*zInput);
					ball.GetComponent<Rigidbody>().AddForce((smoothpos ) * 800);  					
				}
			}
		
  			
	        smoothpos = new Vector3(pos.x/4,pos.y,pos.z/4);
        	ball.GetComponent<Rigidbody>().AddForce((smoothpos ) * 500);
	  //   	Debug.Log("pos : "+pos); 
			// Debug.Log("Rplayer pos : "+transform.position);       
			// Debug.Log("smoothpos : "+smoothpos);    
    	}
    	// if(collision.gameObject.CompareTag("Rplayer")){
    	// 	GameObject.FindWithTag("Rplayer").GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-10)*bungsigi)
    	// }

    	// 플레이어와 충돌시 튕겨나가기
	    if(collision.gameObject.CompareTag("Rplayer")) {
	    	ContactPoint contact = collision.contacts[0];
	    	Vector3 thispos = this.transform.position;
			Vector3 otherpos = GameObject.FindWithTag("Rplayer").transform.position;
	    	particle.transform.position = contact.point;
			particle.GetComponent<ParticleSystem>().Play();
			
			Vector3 cal = new Vector3( (thispos.x - otherpos.x)*50,0f,(thispos.z - otherpos.z)*50 );
			rg.AddForce(cal*1000);
		}
    }

    
    
    

    
     
}