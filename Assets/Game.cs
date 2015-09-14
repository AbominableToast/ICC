using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public static bool p1Turn;

	void Start () {
		p1Turn = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void endTurn(){
		p1Turn = !p1Turn;
	}
}
