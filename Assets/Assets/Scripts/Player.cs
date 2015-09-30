using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//[HideInInspector]
	public ArrayList baseBuildings;

	public int walls;

	public int population;

	public int food;

	public int materials;
	[HideInInspector]
	public int minesRemaining;

	public GameObject items;

	public string[] phases;
	private string currentPhase;
	public int phaseIndex = 0;

	public GameObject baseTower;

	//private int myTurn;
	public Sprite myTurn1;
	public Sprite myTurn2;
	private SpriteRenderer spriteRenderer;

	public static bool hasBuilt = false;

	// Use this for initialization
	void Start (){
		spriteRenderer = GetComponent<SpriteRenderer> ();
		baseBuildings = new ArrayList();
	}



	public void nextPhase(){
		phaseIndex++;
		if (phaseIndex > 2) {
			phaseIndex = 0;
			Player.hasBuilt = false;
			Game.endTurn();
		}
		currentPhase = phases [phaseIndex];
	}

	public int getCurrentPhase(){
		return phaseIndex;
	}


}