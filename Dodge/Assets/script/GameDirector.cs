using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {
	public Text ui_time;
	public Text ui_level;
	public float speed,time,count;
	public int level,flag;
	void Start () {
		time  =0;
		level =0;
		flag=0;
		speed = 100f;
		count = 3f;
	}
	
	void Update () {
		time += Time.deltaTime;
		ui_time.GetComponent<Text>().text = "Time : "+ time.ToString("N1") + "";
		if(Mathf.Round(time) % 5 == 0){
			flag++;
			if(flag == 1 ){
				level+=1;
				ui_level.GetComponent<Text>().text = "Level : "+ level+ "";
				speed+=20f;
				count = count / 2f;
				flag++;
			}
		}
		else{
			flag=0;
		}

		
		
		
		
	
		

	}
}
