using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ArrowView : MonoBehaviour {
	public GameObject arrow;
	Vector3 pos;
	void Start () {
		pos = this.transform.position;
	}
	
	void Update () {	
		if(arrow != null){
			if(arrow.GetComponent<ShootingController>().isShoot){
				GetComponent<Camera>().transform.position = new Vector3(arrow.transform.position.x+0.4f,arrow.transform.position.y-0.5f,arrow.transform.position.z-3f);	
			}
			else{
				this.transform.position = pos;
			}
		}
		if(arrow == null){
			arrow = GameObject.FindWithTag("arrow");
		}
		
	}
}
