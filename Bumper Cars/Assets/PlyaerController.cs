using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyaerController : MonoBehaviour {
	public Rigidbody rg;
	public float speed = 20f,xInput,zInput,maxVelocity ;
	void Start () {
		rg = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		xInput = Input.GetAxis("Horizontal");
		zInput = Input.GetAxis("Vertical");
		Vector3 newVelocity = new Vector3(xInput* speed,0f,zInput* speed);
		rg.AddForce(newVelocity * 20f);

		// rg.AddForce(new Vector3(-1f,0,-1f)*1000);
	}
}
