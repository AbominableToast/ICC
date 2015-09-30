using UnityEngine;
using System.Collections;

public class BaseBuilding : MonoBehaviour {
	
	public GameObject onTop;
	public bool upgraded = false;


	/**
	 * Attaches the gameObject to this baseBuilding 
	 * e.g. a trebuchet to a tower
	 * */
	public void addUpgrade(GameObject upgrade){
		GameObject myUpgrade = Instantiate (upgrade) as GameObject;
		onTop = myUpgrade;
		myUpgrade.transform.parent = this.transform;
		myUpgrade.transform.position = new Vector2 (transform.position.x, transform.position.y + 1);
		upgraded = true;
		Player.hasBuilt = true;
	}
}
