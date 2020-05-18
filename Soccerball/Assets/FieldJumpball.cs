using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldJumpball : MonoBehaviour {
	public GameObject ball;
	void Start () {
		
	}
	
	void Update () {
		
	}
	void OnCollisionEnter(Collision other){

		// 활성화 시, 공 계속 점
		// if (other.gameObject.CompareTag("ball"))
		// {
		// 	ball.GetComponent<Rigidbody>().AddForce(new Vector3(0,6,0)*200);
		
		// }
	}
}
