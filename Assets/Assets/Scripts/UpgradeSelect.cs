using UnityEngine;
using System.Collections;

public class UpgradeSelect : MonoBehaviour {

	public GameObject upgrade;

	void OnMouseUp(){
		if (transform.parent.parent.parent.GetComponent<BaseBuilding>().onTop == null ) {
			transform.parent.parent.parent.GetComponent<BaseBuilding>().addUpgrade (upgrade);
			transform.parent.gameObject.active = false;
		}
	}

	void OnMouseEnter(){

	}

	void OnMouseExit(){

	}
}
