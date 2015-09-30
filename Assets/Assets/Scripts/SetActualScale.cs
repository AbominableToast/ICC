using UnityEngine;
using System.Collections;

public class SetActualScale : MonoBehaviour {

	public Vector2 xAndY;

	// Use this for initialization
	void Start () {
		if (Game.p1Turn) {
			transform.localScale = new Vector2 (xAndY.x, xAndY.y);
		} else {
			transform.localScale = new Vector2 (-xAndY.x, xAndY.y);
		}
	}
}
