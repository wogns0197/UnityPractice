using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemGenerator : MonoBehaviour {

	public GameObject applePrefab;
	public GameObject bombPrefab;
	float span = 1.0f;
	float delta = 0;
	float speed = -0.03f;
	int ratio = 6;
	void Start () {
	}

	public void SetParameter(float span, float speed, int ratio){
		this.span = span;
		this.speed = speed;
		this.ratio = ratio;
	}
	void Update () {
		this.delta += Time.deltaTime; //1초에 하나씩 생성 델타와 시간차 고려(1frame*60 = 1ms*60 = 1sec )
		if(this.delta > this.span){
			GameObject item; //후에 instantiate 통합
			System.Random r = new System.Random(); //System.Random 으로 써야함! >> 유니티 자체의 랜덤함수 없어서 C# 시스템의 난수시스템 사용해야함.(사실있음)
			int percentage = r.Next(1,10); //사과일지 폭탄일지 정하기
			if(percentage < this.ratio){
				this.delta = 0; //1초 지나면 0으로 다시 초기화
				applePrefab.transform.position = new Vector3(r.Next(-1,2), 4, r.Next(-1,2));
				item = Instantiate(applePrefab) as GameObject; // 사과인스턴스 생성	
			}
			else{
				this.delta = 0; //1초 지나면 0으로 다시 초기화
				bombPrefab.transform.position = new Vector3(r.Next(-1,2), 4, r.Next(-1,2));
				item = Instantiate(bombPrefab) as GameObject; // 사과인스턴스 생성
			}
			item.GetComponent<ItemController>().dropSpeed = this.speed;
			

		}
	}
}
