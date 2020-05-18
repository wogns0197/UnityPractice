using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random=UnityEngine.Random;


public class Calculatenum : MonoBehaviour {

	public Text txtobj;
	public TextMesh lefttxt;
	public TextMesh centertxt;
	public TextMesh righttxt;
	public int[] answerlist;
	int wait_time=4;
	float timer;
	public string[] arithmetic = new string[4] {"+","-","*","/"};

	void Start () {
		
	}
	
	void Update () {
		if( timer>wait_time ){
			change();
		}
	}
	public void change(){
		//---------전광판 수정------------
		int num1 = Random.Range(1,40);
		int num2 = Random.Range(1,40);
		int index = Random.Range(0,4);

		String snum1 = num1.ToString();
		String snum2 = num2.ToString();
		String scal = arithmetic[index];

		txtobj.text = snum1+scal+snum2;
		timer = 0.0f;
		//-----------------------------

		
		int[] gndindex = getRandomInt(3,0,3);
		int same1 = ans(num1,num2,scal)+Random.Range(-4,4);
		int same2 = ans(num1,num2,scal)+Random.Range(-5,5);

		//중복제거-----------------------------
		if(same1 == same2){
			while(true){
				same1 = ans(num1,num2,scal)+Random.Range(-4,4);
				same2 = ans(num1,num2,scal)+Random.Range(-5,5);
				if(same1 != same2) break;
			}
		}
		if(ans(num1,num2,scal) == same1){
			same1++;
		}
		if(ans(num1,num2,scal) == same2){
			same2--;
		}
		//----------------------------------
		answerlist = new int[3]{ans(num1,num2,scal),same1,same2};
		string l1 = answerlist[gndindex[0]].ToString();
		lefttxt.text = l1;
		string l2 = answerlist[gndindex[1]].ToString();
		centertxt.text = l2;
		string l3 = answerlist[gndindex[2]].ToString();
		righttxt.text = l3;

		//숫자크기에 맞게 x좌표 조정
		// if( l1.Length == 3){
		// 	lefttxt.transform.position.x += -1;
		// }
		// if( l2.Length == 3){
		// 	centertxt.transform.position.x += -1;
		// }
		// if( l3.Length == 3){
		// 	righttxt.transform.position.x += -1;
		// }
		
	}
	public int[] getRandomInt(int length, int min, int max){
		int[] randArray = new int[length];
		bool isSame;
		for (int i=0 ; i<length; ++i){
			while(true){
				randArray[i] = Random.Range(min,max);
				isSame = false;
				for(int j=0; j<i; ++j){
					if(randArray[j] == randArray[i]){
						isSame = true;
						break;
					}
				}
				if(!isSame) break;
			}
		}
		return randArray;
	}
	public int ans(int a, int b, string arith){
		if(arith.Equals("+")){
			return a+b;
		}
		else if(arith.Equals("-")){
			return a-b;
		}
		else if(arith.Equals("*")){
			return a*b;
		}
		else if(arith.Equals("/")){
			return a/b;
		}
		return 0;
	}
	int where1(int answer){
		if( (lefttxt.text).Equals(answer.ToString()) ) return 0;
		else if( (centertxt.text).Equals(answer.ToString()) ) return 1;
		else if( (righttxt.text).Equals(answer.ToString()) ) return 2;
		return 0;
	}
	// 타 cs접근용 함수
	public int whereisanswer(){
		return where1(answerlist[0]);
	}

}
