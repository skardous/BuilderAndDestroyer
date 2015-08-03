using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelPrint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Text t = gameObject.GetComponent<Text>();
		GameControl gameControl = GameObject.Find ("GameControl").GetComponent<GameControl> ();		
		t.text = "Floor " + gameControl.currentLevel.ToString();
	}
}
