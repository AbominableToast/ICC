using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public int population;
	public int food;
	private Player player1;
	private Player player2;
	public GameObject p1;
	public GameObject p2;

	// Use this for initialization
	void Start () {
		player1 = p1.GetComponent<Player>();
		player2 = p2.GetComponent<Player>();
		
		//spriteEnabled = false;
	}

	int currentPhase(){
		
		if (Game.p1Turn){
			return player1.getCurrentPhase();
		}
		else{
			return player2.getCurrentPhase ();
		}
	}
	
	bool isBuildPhase(){
		if (currentPhase () == 0) {
			return true;
		} else {
			return false;
		}
	}

	
	void depleteFood (){
		if (isBuildPhase()){

		}
}
}