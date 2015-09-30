using UnityEngine;
using System.Collections;

public class backButton : MonoBehaviour {


	void OnMouseUp(){
		transform.parent.gameObject.active = false;
		transform.parent.parent.GetComponent<PopUpInterface>().setSpriteEnabled (true);
	}
}
