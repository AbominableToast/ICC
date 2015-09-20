using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class CombatMMMM : MonoBehaviour {
	
	public GameObject p1;
	public GameObject p2;
	
	private Player player1;
	private Player player2;
	
	
	
	
	
	private bool spriteEnabled;
	private SpriteRenderer spriteRenderer;
	
	// Use this for initialization
	void Start () {
		player1 = p1.GetComponent<Player>();
		player2 = p2.GetComponent<Player>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.enabled = spriteEnabled;
		//spriteEnabled = true;
	}
	
	int currentPhase(){
		
		if (Game.p1Turn){
			return player1.getCurrentPhase();
		}
		else{
			return player2.getCurrentPhase ();
		}
	}
	
	bool isAttackPhase(){
		if (currentPhase() == 2) {
			return true;
		} 
		else {
			return false;
		}
		
	}
	/*
	void drawButton(){
		spriteRenderer.enabled = spriteEnabled;
		if (isAttackPhase()) {
			spriteEnabled = true;
		} 
		else {
			spriteEnabled = false;
		}

		
	} 
*/
	void Update(){	
		spriteRenderer.enabled = spriteEnabled;
		if (isAttackPhase()) {
			spriteEnabled = true;
		} else {
			spriteEnabled = false;
		}
	}

}