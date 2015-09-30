using UnityEngine;
using System.Collections;

public class BuildLocationPopUp : MonoBehaviour , PopUpInterface {

	private BuildLocation parent;
	
	private bool spriteEnabled;
	private SpriteRenderer renderer;

	public GameObject building;

	
	private GameObject player;
	public GameObject defaultPlayer;
	public GameObject menuPopUp;

	void Start(){
		parent = transform.parent.GetComponent<BuildLocation>();
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
		if (!isPhase ("Build") || !correctPlayer() || Player.hasBuilt || transform.parent.GetComponent<BuildLocation>().upgraded) {
			spriteEnabled = false;
			GetComponent<Collider2D> ().enabled = false;
		} else{
			spriteEnabled = true;
			GetComponent<Collider2D> ().enabled = true;
		}
		
		renderer.enabled = spriteEnabled;

	}
	
	void OnMouseDown(){
		if (parent.building == null && correctPlayer() && isPhase("Build") ) {
			foreach(GameObject obj in GameObject.FindGameObjectsWithTag("MenuPopUp")){
				obj.active = false;
				obj.transform.parent.GetComponent<PopUpInterface>().setSpriteEnabled(true);
			}
			menuPopUp.active = true;
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

	public void setSpriteEnabled(bool enabled){
		Debug.Log ("Test");
		spriteEnabled = enabled;
	}
}
