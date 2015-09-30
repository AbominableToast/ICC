using UnityEngine;
using System.Collections;

public class Trebuchet : MonoBehaviour {

	public Player player;
	
	
	void Start(){
		if (Game.p1Turn) {
			player = GameObject.FindGameObjectWithTag ("Player 1").GetComponent<Player> ();
			transform.localScale = new Vector3(2f,2f,1f);
			transform.localPosition = new Vector3 (-0.27f,2.9f,1f);
		} else {
			player = GameObject.FindGameObjectWithTag ("Player 2").GetComponent<Player> ();
			transform.localScale = new Vector3(2f,2f,1f);
			transform.localPosition = new Vector3 (-0.27f,2.9f,1f);
		}
	}
	
	public Player getOwner(){
		return player;
	}
}
