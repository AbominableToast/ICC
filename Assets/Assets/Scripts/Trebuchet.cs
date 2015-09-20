using UnityEngine;
using System.Collections;

public class Trebuchet : MonoBehaviour {

	public Player player;
	
	
	void Start(){
		if (Game.p1Turn) {
			player = GameObject.FindGameObjectWithTag ("Player 1").GetComponent<Player> ();
		} else {
			player = GameObject.FindGameObjectWithTag ("Player 2").GetComponent<Player> ();
		}
	}
	
	public Player getOwner(){
		return player;
	}
}
