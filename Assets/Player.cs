using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//[HideInInspector]
	public ArrayList baseBuildings;
	[HideInInspector]
	public int walls;
	[HideInInspector]
	public int population;
	[HideInInspector]
	public int food;
	[HideInInspector]
	public int materials;
	[HideInInspector]
	public int minesRemaining;

	[HideInInspector]
	public GameObject items;

	public string[] phases;
	private string currentPhase;
	private int phaseIndex = 0;

	public GameObject baseTower;

	// Use this for initialization
	void Start () {
		if (transform.name.Equals ("Player 1")) {
			baseBuildings = new ArrayList();
			addBaseBuilding(baseTower, new Vector2 (transform.position.x + 5, transform.position.y));
		} else {
			baseBuildings = new ArrayList();
			addBaseBuilding(baseTower, new Vector2 (transform.position.x - 5, transform.position.y));
		}
	}

	public void addBaseBuilding(GameObject tower){
		GameObject myTower = Instantiate(tower) as GameObject;
		baseBuildings.Add(myTower);
		myTower.transform.parent = this.transform;
	}

	public void addBaseBuilding(GameObject tower, Vector2 position){
		GameObject myTower = Instantiate(tower) as GameObject;
		baseBuildings.Add(myTower);
		myTower.transform.parent = this.transform;
		myTower.transform.position = position;
	}

	public void nextPhase(){
		phaseIndex++;
		if (phaseIndex > 2) {
			phaseIndex = 0;
			Game.endTurn();
		}
		currentPhase = phases [phaseIndex];
	}

	public int getCurrentPhase(){
		return phaseIndex;
	}

}
