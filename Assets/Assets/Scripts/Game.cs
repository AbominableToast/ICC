using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;


	public static bool p1Turn;

	//public Vector2 indicatorPos;

	void Start () {
		//indicator.transform.position = marker1.position;
		p1Turn = true;
		//indicator = GameObject.FindGameObjectWithTag ("MyTurn");
		//indicatorPos = transform.position.x;
			}
	
	// Update is called once per frame
	void Update () {
	
	}
	/* public void myTurn(){
		if(p1Turn){
			indicator.transform;
		}
	else{

	}
		
		
	} */
	public static void endTurn(){
		p1Turn = !p1Turn;
	}



}
