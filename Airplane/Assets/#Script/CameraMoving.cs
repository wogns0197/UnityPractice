using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.numeric;

public class CameraMoving : MonoBehaviour {
	public GameObject plane;
	Vector3 p_pos,a_rot;
	float dtime = 1f,t = 0f;
	void Start () {
		
	}
	
	public float dtoR(float angle){
		return Mathf.PI*angle/180f;
	}
	// Update is called once per frame
	void Update () {
		a_rot = plane.transform.eulerAngles;
		p_pos = plane.transform.position;
		this.transform.position = new Vector3( 
			p_pos.x 
			+(p_pos.z-this.transform.position.z)*
			(-1f)*Mathf.Tan(dtoR(a_rot.y)),
			p_pos.y+5f,p_pos.z-20f);
		t += Time.deltaTime;
		if(dtime<t){
			// Debug.Log("길이 = "+ (p_pos.z-this.transform.position.z)+" 탄젠트 = "
			// 	+Mathf.Tan(dtoR(a_rot.y)) +"  합은 = "
			// 	+(p_pos.z-this.transform.position.z)*Mathf.Tan(dtoR(a_rot.y)));
			t=0f;
		}
		this.transform.eulerAngles = new Vector3(a_rot.x,a_rot.y,a_rot.z);

	}
}
