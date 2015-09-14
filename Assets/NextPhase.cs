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

	private int index;

	void Start(){
		player1 = p1.GetComponent<Player>();
		player2 = p2.GetComponent<Player>();
		spriteRenderer = GetComponent<SpriteRenderer>();
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
		}
	} 
}
