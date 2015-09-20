using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class TowerPopUp : MonoBehaviour {

	private Tower parent;
	public GameObject catapult;

	private bool spriteEnabled;
	private SpriteRenderer renderer;

	private GameObject player;
	public GameObject defaultPlayer;

	void Start(){
		parent = transform.parent.GetComponent<Tower>();
		spriteEnabled = true;
		renderer = GetComponent<SpriteRenderer>();

		if (defaultPlayer == null) {
			if (Game.p1Turn) {
				player = GameObject.FindGameObjectWithTag ("Player 1");
			} else {
				player = GameObject.FindGameObjectWithTag ("Player 2");
			}
		} else {
			player = defaultPlayer;
		}

	}

	void Update(){	
		renderer.enabled = spriteEnabled;
		if (!isPhase ("Build")) {
			spriteEnabled = false;
		} else if(transform.parent.GetComponent<Tower>().onTop ==null ){
			spriteEnabled = true;
		}
		if (!correctPlayer ()) {
			spriteEnabled = false;
		}
	}

	void OnMouseDown(){
		if (parent.onTop == null && correctPlayer() && isPhase("Build") ) {
			parent.addUpgrade (catapult);
			spriteEnabled = false;
		}
	}

	public bool correctPlayer(){
		if (player.transform.name.Equals ("Player 1") && Game.p1Turn) {
			return true;
		}
		if (player.transform.name.Equals ("Player 2") && !Game.p1Turn) {
			return true;
		}
		return false;
	}

	public bool isPhase(string phase){
		if(phase.Equals("Build")){
			return player.GetComponent<Player>().getCurrentPhase() == 0;
		}
		if(phase.Equals("Ability")){
			return player.GetComponent<Player>().getCurrentPhase() == 1;
		}
		if(phase.Equals("Attack")){
			return player.GetComponent<Player>().getCurrentPhase() == 2;
		}

		return false;
	}


}
