using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour {
	public int xpos,ypos,zpos;
	public GameObject target_prefab;
	public Quaternion startrot;
	void Start () {
		startrot = target_prefab.transform.rotation;
	}
	
	void Update () {
		
	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("arrow")){
			Debug.Log("!!!");
			Destroy(target_prefab);
			xpos = Random.Range(-30,30);
			ypos = Random.Range(6,30);
			zpos = Random.Range(10,35);
			Instantiate(target_prefab, new Vector3(xpos,ypos,zpos) , startrot);
		}
	}
}
