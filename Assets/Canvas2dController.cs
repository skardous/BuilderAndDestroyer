using UnityEngine;
using System.Collections;

public class Canvas2dController : MonoBehaviour {

	public void increaseLevel() {
		GameControl gameControl = GameObject.Find ("GameControl").GetComponent<GameControl> ();
		gameControl.increaseLevel ();
		
	}

	public void decreaseLevel() {
		GameControl gameControl = GameObject.Find ("GameControl").GetComponent<GameControl> ();
		gameControl.decreaseLevel ();
		
	}
}
