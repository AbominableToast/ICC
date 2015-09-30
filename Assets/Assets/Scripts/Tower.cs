using UnityEngine;
using System.Collections;

public class Tower : BaseBuilding {
	
	private GameObject owner;

	public void addObject(GameObject obj){
		onTop = obj;
	}

	public void setOwner(GameObject obj){
		owner = obj;
		if (owner.tag == "Player 1") {
			transform.localScale = new Vector3(1f,0.5f,0.5f);
		} else {
			transform.localScale = new Vector3(-1f,0.5f,0.5f);
		}
	}

	public void clearPopUp(){

	}

}
