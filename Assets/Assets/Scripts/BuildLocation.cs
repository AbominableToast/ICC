using UnityEngine;
using System.Collections;

public class BuildLocation : BaseBuilding {

	public GameObject building;
	public GameObject player1;
	public GameObject player2;

	void Start(){
		player1 = GameObject.FindGameObjectWithTag ("Player 1");
		player2 = GameObject.FindGameObjectWithTag ("Player 2");
	}

	public void addObject(GameObject obj){
		building = obj;
	}

	public void addUpgrade(GameObject upgrade){
		GameObject myUpgrade = Instantiate (upgrade) as GameObject;
		building = myUpgrade;
		myUpgrade.transform.parent = this.transform;
		myUpgrade.transform.position = new Vector2 (transform.position.x, transform.position.y + 1);
		
		if(Game.p1Turn){
			building.GetComponent<Tower>().setOwner(player1);
		}else{
			building.GetComponent<Tower>().setOwner(player2);
		}
		upgraded = true;
		Player.hasBuilt = true;
	}


}
