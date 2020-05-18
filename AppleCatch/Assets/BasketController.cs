using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketController : MonoBehaviour {
	
	GameObject text_point;
	GameObject level;
	GameObject gen;
	int point = 0;	
	void Start(){
		this.text_point = GameObject.Find("Point");
		this.level = GameObject.Find("Level");
		this.gen = GameObject.Find("ItemGenerator");
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Apple"){			
			point+=100;
			text_point.GetComponent<Text>().text = this.point.ToString("F0") + " Point";
		}	
		else{
			point-=100;
			text_point.GetComponent<Text>().text = this.point.ToString("F0") + " Point";
		}
		
		Destroy(other.gameObject);
	}
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
				float x = Mathf.RoundToInt(hit.point.x);
				float z = Mathf.RoundToInt(hit.point.z);
				transform.position = new Vector3(x, 0, z);
			}
		}
		// GameDirtor에 해야하는데 그냥여기가 편하니까 레벨업관리도 여기서 해버린다.
		if(this.point < 400 ){
			this.level.GetComponent<Text>().text = "1";
			this.gen.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 6);
		}
		if(this.point >= 400 & this.point < 900){
			this.level.GetComponent<Text>().text = "2";
			this.gen.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 5);
		}
		if(this.point >= 900 & this.point < 1500){
			this.level.GetComponent<Text>().text = "3";
			this.gen.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 4);
		}
		if(this.point >= 1500 & this.point < 2100){
			this.level.GetComponent<Text>().text = "4";
			this.gen.GetComponent<ItemGenerator>().SetParameter(0.3f, -0.06f, 3);
		}
	}
}
