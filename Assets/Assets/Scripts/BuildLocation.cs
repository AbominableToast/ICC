using UnityEngine;
using System.Collections;

public class BuildLocation : MonoBehaviour {

	public GameObject building;
	public bool upgraded = false;


	public void addObject(GameObject obj){
		building = obj;
	}

	public void addUpgrade(GameObject upgrade){
		GameObject myUpgrade = Instantiate (upgrade) as GameObject;
		building = myUpgrade;
		myUpgrade.transform.parent = this.transform;
		myUpgrade.transform.position = new Vector2 (transform.position.x, transform.position.y + 2);
	}

	public void addUpgrade(GameObject upgrade, Vector2 position){
		if (transform.parent.parent.GetComponent<Player>().getCurrentPhase().Equals ("Build")) {
			GameObject myUpgrade = Instantiate (upgrade) as GameObject;
			building = myUpgrade;
			myUpgrade.transform.parent = this.transform;
			myUpgrade.transform.position = position;
			upgraded = true;
		}
	}

	public void clearPopUp(){

	}

}
