using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class NextPhase : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;

	private Player player1;
	private Player player2;

	public Sprite nextPhase;
	public Sprite endTurn;
	private SpriteRenderer spriteRenderer;

	public GameObject indicator;
	public Transform indicatorMarker1;
	public Transform indicatorMarker2;

	
	public GameObject camera;
	public Transform cameraMarker1;
	public Transform cameraMarker2;


	private int index;

	void Start(){
		player1 = p1.GetComponent<Player>();
		player2 = p2.GetComponent<Player>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		indicator.transform.position = indicatorMarker1.position;
		LerpCamera(cameraMarker1.position);
	}

	void OnMouseDown(){
		if(Game.p1Turn){
			player1.nextPhase();
		}else{
			player2.nextPhase();
		}
		index++;
		if (index == 2) {
			spriteRenderer.sprite = endTurn;
		}
		if (index == 3) {
			spriteRenderer.sprite = nextPhase;
			index = 0;
			switchIndicator();
		}
	}

	//Changes the player turn indicator and also transitions the camera
	public void switchIndicator() {
		StopAllCoroutines();
		if (Game.p1Turn) {
			indicator.transform.position = indicatorMarker1.position;
			StartCoroutine(LerpCamera(cameraMarker1.position));
		} else {
			indicator.transform.position = indicatorMarker2.position;
			StartCoroutine(LerpCamera(cameraMarker2.position));
		}
	}

	public IEnumerator LerpCamera(Vector3 to){
		while(Vector3.Distance (camera.transform.position,to) > 0.05){
			camera.transform.position = Vector3.Lerp(camera.transform.position,to,5f*Time.deltaTime);
			yield return null;
		}
	}

}
