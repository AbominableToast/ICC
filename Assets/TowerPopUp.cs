using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class TowerPopUp : MonoBehaviour {

	private Tower parent;
	public GameObject catapult;

	private bool spriteEnabled;
	private SpriteRenderer renderer;

	void Start(){
		parent = transform.parent.GetComponent<Tower>();
		spriteEnabled = true;
		renderer = GetComponent<SpriteRenderer>();
	}

	void Update(){	
		renderer.enabled = spriteEnabled;
		if (!correctPhase ("Build")) {
			spriteEnabled = false;
		} else if(transform.parent.GetComponent<Tower>().onTop ==null ){
			spriteEnabled = true;
		}
		if (!correctPlayer ()) {
			spriteEnabled = false;
		}
	}

	void OnMouseDown(){
		if (parent.onTop == null && correctPlayer() && correctPhase("Build") ) {
			parent.addUpgrade (catapult);
			spriteEnabled = false;
		}
	}

	bool correctPlayer(){
		if (transform.parent.parent.name.Equals ("Player 1") && Game.p1Turn) {
			return true;
		}
		if (transform.parent.parent.name.Equals ("Player 2") && !Game.p1Turn) {
			return true;
		}

		return false;
	}

	bool correctPhase(string phase){
		if(phase.Equals("Build")){
			Player p = transform.parent.parent.gameObject.GetComponent<Player> ();
			return p.getCurrentPhase() == 0;
		}
		if(phase.Equals("Ability")){
			Player p = transform.parent.parent.gameObject.GetComponent<Player> ();
			return p.getCurrentPhase() == 1;
		}
		if(phase.Equals("Attack")){
			Player p = transform.parent.parent.gameObject.GetComponent<Player> ();
			return p.getCurrentPhase() == 2;
		}

		return false;
	}


}
