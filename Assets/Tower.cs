using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public GameObject onTop;



	public void addObject(GameObject obj){
		onTop = obj;
	}


	public void addUpgrade(GameObject upgrade){
		GameObject myUpgrade = Instantiate (upgrade) as GameObject;
		onTop = myUpgrade;
		myUpgrade.transform.parent = this.transform;
		myUpgrade.transform.position = new Vector2 (transform.position.x, transform.position.y + 1);
	}

	public void addUpgrade(GameObject upgrade, Vector2 position){
		if (transform.parent.GetComponent<Player>().getCurrentPhase().Equals ("Build")) {
			GameObject myUpgrade = Instantiate (upgrade) as GameObject;
			onTop = myUpgrade;
			myUpgrade.transform.parent = this.transform;
			myUpgrade.transform.position = position;
		}
	}

	public void clearPopUp(){

	}

}
