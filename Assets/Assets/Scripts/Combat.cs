using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]

public class Combat : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;

	private Player player1;
	private Player player2;

	private bool spriteEnabled;
	private SpriteRenderer spriteRenderer;
	private int diceRoll;

	public int attackProbabilityModifier = 0;
	public int catapultProbability = 6;
	public int trebuchetProbability = 5;


	// Use this for initialization
	void Start () {
		player1 = p1.GetComponent<Player>();
		player2 = p2.GetComponent<Player>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		//spriteEnabled = false;
	}

	void Update(){
		spriteRenderer.enabled = spriteEnabled;
		if (isAttackPhase()) {
			spriteEnabled = true;
		} 
		else {
			spriteEnabled = false;
		}
	
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
		if (currentPhase () == 2) {
			return true;
		} else {
			return false;
		}
	}

	void OnMouseDown(){
		if (isAttackPhase()) {
			if (Game.p1Turn) {	
				fireWeaponsAt(player2);
			} else {
				fireWeaponsAt(player1);
			}
		}
	}

	void fireWeaponsAt(Player target){
		foreach (GameObject catapult in GameObject.FindGameObjectsWithTag("Catapult")) {
			if( (catapult.GetComponent<Catapult>().getOwner().Equals (player1)&&Game.p1Turn) || (catapult.GetComponent<Catapult>().getOwner().Equals (player2)&&!Game.p1Turn)){
				fireAtTarget(target, catapultProbability + attackProbabilityModifier);
			}
		}
		foreach (GameObject trebuchet in GameObject.FindGameObjectsWithTag("Trebuchet")) {
			if( (trebuchet.GetComponent<Trebuchet>().getOwner().Equals (player1)&&Game.p1Turn) || (trebuchet.GetComponent<Trebuchet>().getOwner().Equals (player2)&&!Game.p1Turn)){
				fireAtTarget(target, trebuchetProbability + attackProbabilityModifier);
			}
		}
	}

	void fireAtTarget(Player target, int probabilityOfHit){

		if (hitTarget(probabilityOfHit)){
			target.walls -= 2;
			Debug.Log ("hit");
		} else {
		Debug.Log ("Miss");
		}
	}

	bool hitTarget(int probabilityOfHit){
		diceRoll = (int)Random.Range (1f,7f);

		if(diceRoll >= probabilityOfHit ){
			return true;
		} else {
			return false;
		}
	
	}

	bool towerIsUpgraded(){
		 GameObject upgradedTower = GameObject.FindWithTag("UpgradedTower");

		if (upgradedTower != null){
			return true;
		} else {
			return false;
		}
	}

}
