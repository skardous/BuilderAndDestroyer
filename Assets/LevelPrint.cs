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
		t.text = GameControl.control.currentLevel.ToString();
	}
}
