using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallpushball : MonoBehaviour {
	public GameObject ball;
	public GameObject Lplayer;
	public GameObject Rplayer;
	
	float bungsigi = 10.0f;
	void Start () {
		
	}
	void Update () {
		
	}
	 void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("ball"))
		{
			//top
			if(gameObject.transform.position.z == 10) {
				ball.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-10)*bungsigi);
			}
			//bottom
			else if(gameObject.transform.position.z <= -10){
				ball.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,10)*bungsigi);
			}
			//right
			else if(gameObject.transform.position.x == 20){
				ball.GetComponent<Rigidbody>().AddForce(new Vector3(10,0,0)*bungsigi);
			}
			//left
			else if(gameObject.transform.position.x == -20) {
				ball.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-10)*bungsigi);
			}
	    }
	    if(other.gameObject.CompareTag("Lplayer")){
	    	if(gameObject.transform.position.z == 10) {
				Lplayer.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-10)*bungsigi);
				
			}
			//bottom
			else if(gameObject.transform.position.z <= -10){
				Lplayer.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,10)*bungsigi);
			}
			//right
			else if(gameObject.transform.position.x == 20){
				Lplayer.GetComponent<Rigidbody>().AddForce(new Vector3(10,0,0)*bungsigi);
			}
			//left
			else if(gameObject.transform.position.x == -20) {
				Lplayer.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-10)*bungsigi);
			}
	    }
	    if(other.gameObject.CompareTag("Rplayer")){
	    	if(gameObject.transform.position.z == 10) {
				Rplayer.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-10)*bungsigi);
			}
			//bottom
			else if(gameObject.transform.position.z <= -10){
				Rplayer.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,10)*bungsigi);
			}
			//right
			else if(gameObject.transform.position.x == 20){
				Rplayer.GetComponent<Rigidbody>().AddForce(new Vector3(10,0,0)*bungsigi);
			}
			//left
			else if(gameObject.transform.position.x == -20) {
				Rplayer.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-10)*bungsigi);
			}
	    }
	}

}
